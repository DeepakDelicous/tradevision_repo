<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="TranshipmentView.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="RET.TranshipmentView" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>   

<style type="text/css">
.ajax__calendar_container {
    z-index: 1000;
}

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

    function openTab(tabId) {
        var tabContainer = $find("<%= TabContainer1.ClientID %>");
        tabContainer.set_activeTabIndex(tabId - 1);
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
<asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="transhipment">
<ProgressTemplate>
<div class="overlay">
<div style=" z-index: 1000; margin-top:300px; opacity: 1; -moz-opacity: 1;">
<center>
<img alt="" src="Loader.gif" width="100" height="100" /></center>
</div>
</div>
</ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdatePanel ID="transhipment" UpdateMode="Conditional" runat="server">
<ContentTemplate>
<div class="row top-pad" style="margin-top: -17px;">
<%-- <div class="col-md-12">
<ol class="breadcrumb">
<li class="active"><i class="fa fa-dashboard"></i>&nbsp;&nbsp;Transhipment</li>
</ol>
</div>--%>
</div>
<div class="container ">

<div class="row">

<%-- <div class="container bootstrap snippet">
<div class="row top-pad">
<div class="col-md-12">
<ol class="breadcrumb">

</ol>
</div>
</div>
</div> --%>

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
<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
ShowSummary="False" ValidationGroup="Validation" />
<asp:Button ValidationGroup="Validation" ID="BtnSaveDraft" class="btn1" Visible ="false" runat="server" OnClientClick="$('li:eq(2)', $('.nav-tabs')).tab('show')" OnClick="BtnSaveDraft_Click" Text="Save As Draft" />


</div>




<div class="btn-group pull-right">
<asp:Button ID="BtnExit" runat="server" class="btn1 btn-danger" Visible="false" OnClick="BtnExit_Click" Text="Exit Form" />


</div>
</div>
</div>
<br /><br />
<div class="row">
<cc1:ModalPopupExtender ID="POPUPERR" runat="server" PopupControlID="PanelErr" TargetControlID="BtnCls"
OkControlID="BtnCls" BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>


<asp:Panel ID="PanelErr" runat="server" CssClass="modalPopup" Style="display: none;">
<div class="header" >

</div>
<div class="body">
<asp:GridView ID="GridError" PageSize="5" AllowPaging="True" OnPageIndexChanging="GridError_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false" Visible="false">
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
            <div class="flex flex-col justify-center items-center relative" id="divSummary" runat="server" onclick="openTab(7)"  > 
                <div class="text-center text-gray-500 md:text-base text-[10px] mb-2">
                    Summary
               
                </div>
                <div class="w-[14px] h-[14px] bg-transparent border-2 border-[#BCBCC3] rounded-full relative"></div>
            </div>
        </div>


<div class="board-inner">


<!-- Tab panes -->


<cc1:TabContainer ID="TabContainer1" AutoPostBack="true" runat="server" ActiveTabIndex="0" CssClass="Tab" Style="margin-top: 50px;" OnActiveTabChanged="TabContainer1_ActiveTabChanged" OnLoad="TabContainer1_ActiveTabChanged" >

<cc1:TabPanel ID="Header" CssClass="ajax__tab_header" runat="server" HeaderText="Header">
<ContentTemplate>
<asp:UpdatePanel ID="transhipheader" UpdateMode="Conditional" runat="server">
<ContentTemplate>
<div class="row">
<div class="col-sm-6">
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Message Type
</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" ID="TxtMsgType" Text="TNPDEC" runat="server" TabIndex="1" type="text" Enabled="false"></asp:TextBox>
</div>
</div>
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Declaration Type

</label>
<div class="col-sm-9">
<asp:DropDownList CssClass="drop" BackColor="#e8f0fe" ID="DrpDecType" OnSelectedIndexChanged="DrpDecType_SelectedIndexChanged" AutoPostBack="true" Height="28" AppendDataBoundItems="true" TabIndex="2" runat="server">
</asp:DropDownList>

</div>
</div>
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Prev Permit No

</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" ID="TxtPrevPerNO" runat="server" type="text" TabIndex="3"></asp:TextBox>
</div>
</div>
<div id="cargo" runat="server" class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Cargo Pack Type

</label>
<div class="col-sm-9">
<asp:DropDownList CssClass="drop" ID="DrpCargoPackType" BackColor="#e8f0fe" Height="28" OnSelectedIndexChanged="DrpCargoPackType_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true" TabIndex="4" runat="server">
</asp:DropDownList>

</div>
</div>
<div id="Inward" runat="server" class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
<p id="inwared" runat="server" style="margin-left: -0px;">In Trans Mode</p>

</label>
<div class="col-sm-9">
<asp:DropDownList CssClass="drop" ID="DrpInwardtrasMode" BackColor="#e8f0fe" OnSelectedIndexChanged="DrpInwardtrasMode_SelectedIndexChanged" AutoPostBack="true" Height="28" AppendDataBoundItems="true" TabIndex="5" runat="server">
</asp:DropDownList>

</div>
</div>
<div id="Outward" runat="server" class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
<p id="q" runat="server" style="margin-left: -0px;">Out Trans Mode</p>

</label>
<div class="col-sm-9">
<asp:DropDownList CssClass="drop" ID="DrpOutwardtrasMode" OnSelectedIndexChanged ="DrpOutwardtrasMode_SelectedIndexChanged" AutoPostBack="true" Height="28" AppendDataBoundItems="true" TabIndex="6" runat="server">
</asp:DropDownList>

</div>
</div>
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
BG Indicator
</label>
<div class="col-sm-9">
<asp:DropDownList CssClass="drop" ID="DrpBGIndicator" Height="28" AppendDataBoundItems="true" TabIndex="7" runat="server">
</asp:DropDownList>
</div>
</div>
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
override Ex Rate

</label>
<div class="col-sm-9">
<asp:CheckBox ID="ChkOverrExgRate" Enabled="false" runat="server" TabIndex="8"/>
</div>
</div>
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Supply indicator
</label>
<div class="col-sm-9">
<asp:CheckBox ID="ChkSupplyIndicator" runat="server" TabIndex="9"/>
</div>
</div>
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Ref Document
</label>
<div class="col-sm-9">
<asp:CheckBox ID="ChkRefDoc" OnCheckedChanged="ChkRefDoc_CheckedChanged" AppendDataBoundItems="true" AutoPostBack="true" runat="server" TabIndex="10"/>
</div>
</div>
</div>
<div class="col-sm-6">
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Mailbox ID
</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" runat="server" BackColor="#e8f0fe" Text="" type="text" ID="TxtTradeMailID"></asp:TextBox>

</div>
</div>
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Declarant Name
</label>
<div class="col-sm-9">

<asp:TextBox autocomplete="off" ID="TxtDecName" BackColor="#e8f0fe" Text="" runat="server" type="text"></asp:TextBox>

</div>
</div>
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Declaration Code
</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" ID="TxtDecCode" BackColor="#e8f0fe" Text="" runat="server" type="text"></asp:TextBox>

</div>
</div>
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">Declarant Tel</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" ID="TxtDecTelephone" BackColor="#e8f0fe" Text="" runat="server" type="text"></asp:TextBox>

</div>
</div>
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">CR UEI No</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" ID="TxtCRUEINO" BackColor="#e8f0fe" Text="" runat="server" type="text" ></asp:TextBox>

</div>
</div>


<div class="row">
<div class="col-sm-12">
<form class="form" data-toggle="validator" action="##" method="post" id="registrationForm">
<asp:Label ID="txt_code" Visible="false" runat="server"></asp:Label>
<br />
<div id="recnotvisible" runat="server" class="row">
<div class="row">
<div class="col-sm-12">
<div class="row Borderdiv" style="width: 80%">
ADDITIONAL RECIPIENTS
</div>
<br />
<div class="form-group row">
<label for="staticEmail" style ="font-family :'Times New Roman';" class="col-sm-3 col-form-label">RECIPIENTS</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" ID="TxtRECPT1" Width="265" runat="server" TabIndex="19" type="text" Style="text-transform: uppercase"></asp:TextBox>

</div>
</div>

<div class="form-group row">
<label for="staticEmail" style ="font-family :'Times New Roman';" class="col-sm-3 col-form-label">RECIPIENTS 2</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" ID="TxtRECPT2" Width="265" runat="server" TabIndex="20" type="text" Style="text-transform: uppercase"></asp:TextBox>

</div>
</div>


<div class="form-group row">
<label for="staticEmail" style ="font-family :'Times New Roman';" class="col-sm-3 col-form-label">RECIPIENTS 3</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" ID="TxtRECPT3" Width="265" runat="server" onkeypress="return isNumber(event)" TabIndex="21" type="text" Style="text-transform: uppercase"></asp:TextBox>

</div>
</div>
<br />
<br />
</div>
</div>
</div>
</form>
</div>
</div>



</div>
</div>

<div class="row">
<div class="col-sm-12" id="Document" runat="server">
<div class="row">
<div class="col-sm-6">
<br />
<div class="row Borderdiv" style="width: 100%">
License
</div>
<br />
<div class="row">
<div class="col-sm-6">
<asp:TextBox autocomplete="off" ID="TxtLicense1" Width="275" runat="server" TabIndex="11" type="text"></asp:TextBox><br />
<br />
<asp:TextBox autocomplete="off" ID="TxtLicense2" Width="275" runat="server" TabIndex="12" type="text"></asp:TextBox><br />
<br />
<asp:TextBox autocomplete="off" ID="TxtLicense3" Width="275" runat="server" TabIndex="13" type="text"></asp:TextBox><br />
<br />
</div>
<div class="col-sm-6">
<asp:TextBox autocomplete="off" ID="TxtLicense4" Width="275" runat="server" TabIndex="14" type="text"></asp:TextBox><br />
<br />
<asp:TextBox autocomplete="off" ID="TxtLicense5" Width="275" runat="server" TabIndex="15" type="text"></asp:TextBox><br />
<br />
</div>
</div>

</div>
<div class ="col-sm-6">
<div class="row">


<br />
<div class="col-sm-12">
<div class="row Borderdiv" style="width: 100%">
Attachment Document
</div>

<div class="row">
<div class="col-sm-5">
<p>Document Type</p>
<asp:DropDownList CssClass="drop" ID="DrpDocType" Width="250" Height="32" AppendDataBoundItems="true" TabIndex="16" runat="server">
</asp:DropDownList><br />

</div>
<div class="col-sm-5">
<p>Attachment</p>
<asp:FileUpload ID="FileUpload1" runat="server" TabIndex="17" class="btn" AllowMultiple="true" />

</div>
<div class="col-sm-2">
<p>Upload</p>
<asp:Button runat="server" ID="Btn_Upload" TabIndex="18" ValidationGroup="Validationbtn" class="btn btn-success" Text="Upload" OnClick="Btn_Upload_Click" />

</div>
</div>


<hr />
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

<br />
</div>

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
                                                                                                   
                                                                                                </asp:GridView>
                                                                            </div>
                                                                        </div>
                                                                       </ContentTemplate>

                                                                    </asp:UpdatePanel>

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
<Triggers >
<asp:PostBackTrigger ControlID ="Btn_Upload" />
</Triggers>
</asp:UpdatePanel>
</ContentTemplate>
</cc1:TabPanel>

<cc1:TabPanel ID="Party" runat="server" CssClass="nn" HeaderText="Party">
<ContentTemplate>
<asp:UpdatePanel ID="transhipparty" UpdateMode="Conditional" runat="server">
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
<asp:ImageButton ID="btntransdec" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" Style="margin-top: -250px;" />

<asp:Button ID="DECPLUS" runat="server" CssClass="plusbtn" BackColor="Transparent" BorderWidth="0px" Font-Size="Small" ValidationGroup="ItemMasterValidation1" OnClick="DECPLUS_Click" Text="+" />
</div>
</div>


</label>
<cc1:ModalPopupExtender ID="popuptransdec" runat="server" PopupControlID="pnltransdec" TargetControlID="btntransdec"
OkControlID="btnYestransdec" CancelControlID="btnNotransdec" BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>

<asp:Panel ID="pnltransdec" runat="server" CssClass="modalPopup" Style="display: none">
<div class="header">
Declarant Company
</div>
<div class="body">
<asp:UpdatePanel ID="uptransdec" runat="server" UpdateMode="Conditional">
<ContentTemplate>
<asp:TextBox autocomplete="off" ID="DecSearch" OnTextChanged="DecSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
<br />
<asp:GridView ID="DECCOMPSearGRID" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="DECCOMPSearGRID_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" OnRowCommand="DECCOMPSearGRID_RowCommand" OnRowDataBound="DECCOMPSearGRID_RowDataBound" AutoGenerateColumns="false">
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
<asp:LinkButton ID="lnkRequestID" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="lnkRequestID_Command">Select </asp:LinkButton>
</ItemTemplate>
</asp:TemplateField>
</Columns>
</asp:GridView>
</ContentTemplate>



</asp:UpdatePanel>
</div>
<div class="footer" align="right">
<asp:Button ID="btnYestransdec" runat="server" Text="Yes" CssClass="yes" />
<asp:Button ID="btnNotransdec" runat="server" Text="No" CssClass="no" />
</div>
</asp:Panel>
<div class="col-sm-4">
<asp:TextBox autocomplete="off" runat="server" Width="100" type="text" OnTextChanged="TxtDecCompCode_TextChanged" placeholder="Code" AutoPostBack="true" ID="TxtDecCompCode" TabIndex="25"></asp:TextBox>

<cc1:AutoCompleteExtender ServiceMethod="GetListofCountries"
MinimumPrefixLength="1"
CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
TargetControlID="TxtDecCompCode"
ID="AutoCompleteExtender1" runat="server" FirstRowSelected="true">
</cc1:AutoCompleteExtender>
</div>
</div>

</div>
<div class="col-sm-2">
<div class="form-group row">

<div class="col-sm-12">
<asp:TextBox autocomplete="off" ID="TxtDecCompCRUEI" BackColor="#e8f0fe" placeholder="CRUEI" Width="170" runat="server" Enabled="false" ValidationGroup="Validation" type="text"></asp:TextBox>

<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtDecCompCRUEI" ID="RegularExpressionValidator37" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator><br />
</div>
</div>

</div>
<div class="col-sm-3">
<div class="form-group row">

<div class="col-sm-12">
<asp:TextBox autocomplete="off" ID="TxtDecCompName" BackColor="#e8f0fe" placeholder="Name" Width="275" runat="server" Enabled="false" ValidationGroup="Validation" type="text"></asp:TextBox>

<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtDecCompName" ID="RegularExpressionValidator18" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
</div>
</div>

</div>
<div class="col-sm-3">
<div class="form-group row">

<div class="col-sm-12">
<asp:TextBox autocomplete="off" ID="TxtDecCompName1" placeholder="Name1" Width="275" runat="server" ValidationGroup="Validation" Enabled="false" type="text"></asp:TextBox>
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtDecCompName1" ID="RegularExpressionValidator19" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
</div>
</div>

</div>
</div>
<div class="row" id="ImportDiv" runat="server">

<div id="transimp" visible ="false" runat ="server">



<div class="col-sm-4">
<div class="form-group row">
<label for="staticEmail" class="col-sm-8 col-form-label">
<div class="row">
<div class="col-sm-8">
Importer
</div>
<div class="col-sm-4">
<asp:ImageButton ID="btntransimp" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" Style="margin-top: -250px;" />
<asp:Button ID="BtnImpADD" runat="server" CssClass="plusbtn" BackColor="Transparent" BorderWidth="0px" Font-Size="Small" ValidationGroup="Importer" OnClick="BtnImpADD_Click" Text="+" />
</div>
</div>



<cc1:ModalPopupExtender ID="popuptransimp" runat="server" PopupControlID="pnltransimp" TargetControlID="btntransimp"
OkControlID="btnYestransimp" CancelControlID="btnNotransimp" BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>

<asp:Panel ID="pnltransimp" runat="server" CssClass="modalPopup" Style="display: none">
<div class="header">
Importer
</div>
<div class="body">
<asp:UpdatePanel ID="uptransimp" runat="server" UpdateMode="Conditional">
<ContentTemplate>
<asp:TextBox autocomplete="off" ID="ImporterSearch" OnTextChanged="ImporterSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
<br />
<asp:GridView ID="ImporterGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="ImporterGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" OnRowCommand="ImporterGrid_RowCommand" OnRowDataBound="ImporterGrid_RowDataBound" runat="server" AutoGenerateColumns="false">
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
<asp:LinkButton ID="LnkImport" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LnkImport_Command">Select </asp:LinkButton>
</ItemTemplate>
</asp:TemplateField>
</Columns>
</asp:GridView>
</ContentTemplate>


</asp:UpdatePanel>
</div>
<div class="footer" align="right">
<asp:Button ID="btnYestransimp" runat="server" Text="Yes" CssClass="yes" />
<asp:Button ID="btnNotransimp" runat="server" Text="No" CssClass="no" />
</div>
</asp:Panel>
<%-- <i class='fa fa-search' data-toggle="modal" data-target="#ImportSearch"></i>--%>
<%-- <asp:UpdatePanel ID="UpdatePanel2" runat="server">
<ContentTemplate>--%>


</label>
<div class="col-sm-4">
<asp:TextBox autocomplete="off" runat="server" Width="100" placeholder="Code" type="text" ID="TxtImpCode" OnTextChanged="TxtImpCode_TextChanged" AutoPostBack="true" TabIndex="26"></asp:TextBox>

<cc1:AutoCompleteExtender ServiceMethod="GetImpcode"
MinimumPrefixLength="1"
CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
TargetControlID="TxtImpCode"
ID="AutoCompleteExtender2" runat="server" FirstRowSelected="true">
</cc1:AutoCompleteExtender>
</div>
</div>

</div>
<div class="col-sm-2">
<div class="form-group row">

<div class="col-sm-12">
<asp:TextBox autocomplete="off" ID="TxtImpCRUEI" BackColor="#e8f0fe" placeholder="CRUEI" Width="170" runat="server" TabIndex="27" type="text"></asp:TextBox>

<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtImpCRUEI" ID="RegularExpressionValidator36" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator><br />
</div>
</div>

</div>
<div class="col-sm-3">
<div class="form-group row">

<div class="col-sm-12">
<asp:TextBox autocomplete="off" ID="TxtImpName" BackColor="#e8f0fe" placeholder="Name" Width="275" runat="server" ValidationGroup="Validation" TabIndex="28" type="text"></asp:TextBox>

<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtImpName" ID="RegularExpressionValidator5" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
</div>
</div>

</div>
<div class="col-sm-3">
<div class="form-group row">

<div class="col-sm-12">
<asp:TextBox autocomplete="off" ID="TxtImpName1" placeholder="Name1" Width="275" runat="server" TabIndex="29" type="text"></asp:TextBox>
<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtImpName1" ID="RegularExpressionValidator6" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
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
Handling Agent
</div>
<div class="col-sm-4">
<asp:ImageButton ID="btntransexporter" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" Style="margin-top: -250px;" />

<%--<i class='fa fa-search' data-toggle="modal" data-target="#EXPORTER"></i>--%>
<asp:Button ID="BtnExpAdd" CssClass="plusbtn" BackColor="Transparent" BorderWidth="0px" Font-Size="Small" runat="server" ValidationGroup="Importer" OnClick="BtnExpAdd_Click" Text="+" />
</div>
</div>






</label>
<cc1:ModalPopupExtender ID="popuptransexp" runat="server" PopupControlID="pnltransexp" TargetControlID="btntransexporter"
OkControlID="btnYestransexp" CancelControlID="btnNtransexpo" BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>

<asp:Panel ID="pnltransexp" runat="server" CssClass="modalPopup" Style="display: none">
<div class="header">
Handling Agent
</div>
<div class="body">
<asp:UpdatePanel ID="uptransexp" runat="server" UpdateMode="Conditional">
<ContentTemplate>
<asp:TextBox autocomplete="off" ID="ExporterSearch" OnTextChanged="ExporterSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
<br />
<asp:GridView ID="ExporterGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="ExporterGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" OnRowCommand="ExporterGrid_RowCommand" OnRowDataBound="ExporterGrid_RowDataBound" AutoGenerateColumns="false">
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
<asp:LinkButton ID="LnkExporter" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LnkExporter_Command">Select </asp:LinkButton>
</ItemTemplate>
</asp:TemplateField>
</Columns>
</asp:GridView>
</ContentTemplate>



</asp:UpdatePanel>
</div>
<div class="footer" align="right">
<asp:Button ID="btnYestransexp" runat="server" Text="Yes" CssClass="yes" />
<asp:Button ID="btnNtransexpo" runat="server" Text="No" CssClass="no" />
</div>
</asp:Panel>
<div class="col-sm-4">
<asp:TextBox autocomplete="off" runat="server" Width="100" type="text" ID="TxtExpCode" placeholder="Code" OnTextChanged="TxtExpCode_TextChanged" AutoPostBack="true" TabIndex="30"></asp:TextBox>
<cc1:AutoCompleteExtender ServiceMethod="GetExpcode"
MinimumPrefixLength="1"
CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
TargetControlID="TxtExpCode"
ID="AutoCompleteExtender3" runat="server" FirstRowSelected="true">
</cc1:AutoCompleteExtender>
</div>
</div>

</div>
<div class="col-sm-2">
<div class="form-group row">

<div class="col-sm-12">
<asp:TextBox autocomplete="off" ID="TxtExpCRUEI" placeholder="CRUEI" Width="170" runat="server" ValidationGroup="Validation" TabIndex="31" type="text"></asp:TextBox>

<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtExpCRUEI" ID="RegularExpressionValidator9" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
</div>
</div>

</div>
<div class="col-sm-3">
<div class="form-group row">

<div class="col-sm-12">
<asp:TextBox autocomplete="off" ID="TxtExpName" placeholder="Name" Width="275" runat="server" ValidationGroup="Validation" TabIndex="32" type="text"></asp:TextBox>

<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtExpName" ID="RegularExpressionValidator7" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
</div>
</div>

</div>
<div class="col-sm-3">
<div class="form-group row">

<div class="col-sm-12">
<asp:TextBox autocomplete="off" ID="TxtExpName1" placeholder="Name1" Width="275" runat="server" ValidationGroup="Validation" TabIndex="33" type="text"></asp:TextBox>
<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtExpName1" ID="RegularExpressionValidator8" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
</div>
</div>

</div>
</div>
<div id="inw" runat="server" class="row" style="margin-left:0px;">
<div class="row">
<div class="col-sm-4">
<div class="form-group row" style="margin-right: -7px;">
<label for="staticEmail" class="col-sm-8 col-form-label">

<div class="row">
<div class="col-sm-8">
Inward Carrier Agent
</div>
<div class="col-sm-4">
<asp:ImageButton ID="btntransinw" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" Style="margin-top: -250px;" />



<asp:Button ID="InwardAdd" runat="server" CssClass="plusbtn" BackColor="Transparent" BorderWidth="0px" Font-Size="Small" ValidationGroup="INWARD" OnClick="InwardAdd_Click" Text="+" />

</div>
</div>


</label>

<cc1:ModalPopupExtender ID="popuptransinw" runat="server" PopupControlID="pnltransinw" TargetControlID="btntransinw"
OkControlID="btnYestransinw" CancelControlID="btnNotransinw" BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>

<asp:Panel ID="pnltransinw" runat="server" CssClass="modalPopup" Style="display: none">
<div class="header">
Inward Carrier Agent
</div>
<div class="body">
<asp:UpdatePanel ID="uptransinw" runat="server" UpdateMode="Conditional">
<ContentTemplate>
<asp:TextBox autocomplete="off" ID="InwardSearch" OnTextChanged="InwardSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
<br />
<asp:GridView ID="InwardGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="InwardGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" OnRowCommand="InwardGrid_RowCommand" OnRowDataBound="InwardGrid_RowDataBound" AutoGenerateColumns="false">
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
<asp:LinkButton ID="LmkInward" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LmkInward_Command">Select </asp:LinkButton>
</ItemTemplate>
</asp:TemplateField>
</Columns>
</asp:GridView>
</ContentTemplate>



</asp:UpdatePanel>
</div>
<div class="footer" align="right">
<asp:Button ID="btnYestransinw" runat="server" Text="Yes" CssClass="yes" />
<asp:Button ID="btnNotransinw" runat="server" Text="No" CssClass="no" />
</div>
</asp:Panel>
<div class="col-sm-4">
<asp:TextBox autocomplete="off" runat="server" Width="100" type="text" placeholder="Code" AutoPostBack="true" ID="InwardCode" OnTextChanged="InwardCode_TextChanged" TabIndex="34"></asp:TextBox>
<cc1:AutoCompleteExtender ServiceMethod="GetInwcode"
MinimumPrefixLength="1"
CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
TargetControlID="InwardCode"
ID="AutoCompleteExtender4" runat="server" FirstRowSelected="true">
</cc1:AutoCompleteExtender>
</div>
</div>

</div>
<div class="col-sm-2" >
<div class="form-group row">

<div class="col-sm-12" >
<asp:TextBox autocomplete="off" ID="InwardCRUEI" placeholder="CRUEI" BackColor="#e8f0fe" Width="170" ValidationGroup="Validation" runat="server" TabIndex="35" type="text"></asp:TextBox>

<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="InwardCRUEI" ID="RegularExpressionValidator11" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
</div>
</div>

</div>
<div class="col-sm-3" style="margin-right: -7px;">
<div class="form-group row" >

<div class="col-sm-12">
<asp:TextBox autocomplete="off" ID="InwardName" placeholder="Name" BackColor="#e8f0fe" ValidationGroup="Validation" Width="275" runat="server" TabIndex="36" type="text"></asp:TextBox>

<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="InwardName" ID="RegularExpressionValidator14" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
</div>
</div>

</div>
<div class="col-sm-3" style="margin-right: -7px;">
<div class="form-group row" >

<div class="col-sm-12">
<asp:TextBox autocomplete="off" ID="InwardName1" placeholder="Name1" Width="275" ValidationGroup="Validation" runat="server" TabIndex="37" type="text"></asp:TextBox>
<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="InwardName1" ID="RegularExpressionValidator10" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
</div>
</div>

</div>
</div>
</div>
<div id="outw" runat="server" class="row" style="margin-left:0px;">
<div class="row">
<div class="col-sm-4">
<div class="form-group row" style="margin-right: -7px;">
<label for="staticEmail" class="col-sm-8 col-form-label">
<div class="row">
<div class="col-sm-8">
Outward Carrier Agent
</div>
<div class="col-sm-4">
<asp:ImageButton ID="btntransoutward" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" Style="margin-top: -250px;" />

<%-- <i class='fa fa-search' data-toggle="modal" data-target="#Outward1"></i>--%>
<asp:Button ID="OutwardAdd" runat="server" CssClass="plusbtn" BackColor="Transparent" BorderWidth="0px" Font-Size="Small" ValidationGroup="Outward" OnClick="OutwardAdd_Click" Text="+" />
</div>
</div>




</label>
<cc1:ModalPopupExtender ID="popuptransoutward" runat="server" PopupControlID="pnltransoutward" TargetControlID="btntransoutward"
OkControlID="btnYestransoutward" CancelControlID="btnNotransoutward" BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>

<asp:Panel ID="pnltransoutward" runat="server" CssClass="modalPopup" Style="display: none">
<div class="header">
Outward Carrier Agent
</div>
<div class="body">
<asp:UpdatePanel ID="uptransoutward" runat="server" UpdateMode="Conditional">
<ContentTemplate>
<asp:TextBox autocomplete="off" ID="OutwardSearch" OnTextChanged="OutwardSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
<br />
<asp:GridView ID="OutwardGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="OutwardGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" OnRowCommand="OutwardGrid_RowCommand" OnRowDataBound="OutwardGrid_RowDataBound" AutoGenerateColumns="false">
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



</asp:UpdatePanel>
</div>
<div class="footer" align="right">
<asp:Button ID="btnYestransoutward" runat="server" Text="Yes" CssClass="yes" />
<asp:Button ID="btnNotransoutward" runat="server" Text="No" CssClass="no" />
</div>
</asp:Panel>
<div class="col-sm-4">
<asp:TextBox autocomplete="off" runat="server" Width="100" placeholder="Code" type="text" AutoPostBack="true" ID="OutwardCode" OnTextChanged="OutwardCode_TextChanged" TabIndex="38"></asp:TextBox>
<cc1:AutoCompleteExtender ServiceMethod="GetOutWard"
MinimumPrefixLength="1"
CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
TargetControlID="OutwardCode"
ID="AutoCompleteExtender5" runat="server" FirstRowSelected="true">
</cc1:AutoCompleteExtender>
</div>
</div>

</div>
<div class="col-sm-2">
<div class="form-group row">

<div class="col-sm-12">
<asp:TextBox autocomplete="off" ID="OutwardCRUEI" BackColor="#e8f0fe" placeholder="CRUEI" Width="170" runat="server" TabIndex="39" type="text" ValidationGroup="Validation"></asp:TextBox>
<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="OutwardCRUEI" ID="RegularExpressionValidator15" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>

</div>
</div>

</div>
<div class="col-sm-3">
<div class="form-group row">

<div class="col-sm-12">
<asp:TextBox autocomplete="off" ID="OutwardName" BackColor="#e8f0fe" placeholder="Name" Width="275" runat="server" TabIndex="40" type="text" ValidationGroup="Validation"></asp:TextBox>

<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="OutwardName" ID="RegularExpressionValidator12" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
</div>
</div>

</div>
<div class="col-sm-3">
<div class="form-group row">

<div class="col-sm-12">
<asp:TextBox autocomplete="off" ID="OutwardName1" placeholder="Name1" Width="275" runat="server" TabIndex="41" type="text"></asp:TextBox>
<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="OutwardName1" ID="RegularExpressionValidator13" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
</div>
</div>

</div>
</div>
</div>


<div class="row">

<div id="transfreight" visible ="false" runat ="server">

<div class="col-sm-4">
<div class="form-group row">
<label for="staticEmail" class="col-sm-8 col-form-label">
<div class="row">
<div class="col-sm-8">
Freight Forwarder
</div>
<div class="col-sm-4">
<asp:ImageButton ID="btntransfreight" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" Style="margin-top: -250px;" />

<%-- <i class='fa fa-search' data-toggle="modal" data-target="#Frieght"></i>--%>
<asp:Button ID="BtnFrieghtAdd" CssClass="plusbtn" runat="server" ValidationGroup="FREIGHT" OnClick="BtnFrieghtAdd_Click" Text="+" />
</div>
</div>




</label>
<cc1:ModalPopupExtender ID="popuptransfreight" runat="server" PopupControlID="pnltransfreight" TargetControlID="btntransfreight"
OkControlID="btnYestransfreight" CancelControlID="btnNotransfreight" BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>

<asp:Panel ID="pnltransfreight" runat="server" CssClass="modalPopup" Style="display: none">
<div class="header">
Freight Forwarder
</div>
<div class="body">
<asp:UpdatePanel ID="uptransfreight" runat="server" UpdateMode="Conditional">
<ContentTemplate>
<asp:TextBox autocomplete="off" ID="FrieghtSearch" OnTextChanged="FrieghtSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
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


</asp:UpdatePanel>
</div>
<div class="footer" align="right">
<asp:Button ID="btnYestransfreight" runat="server" Text="Yes" CssClass="yes" />
<asp:Button ID="btnNotransfreight" runat="server" Text="No" CssClass="no" />
</div>
</asp:Panel>
<div class="col-sm-4">
<asp:TextBox autocomplete="off" runat="server" Width="100" placeholder="Code" OnTextChanged="FrieghtCode_TextChanged" AutoPostBack="true" type="text" ID="FrieghtCode" TabIndex="42"></asp:TextBox>
<cc1:AutoCompleteExtender ServiceMethod="GetFrieght"
MinimumPrefixLength="1"
CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
TargetControlID="FrieghtCode"
ID="AutoCompleteExtender6" runat="server" FirstRowSelected="true">
</cc1:AutoCompleteExtender>
</div>
</div>

</div>
<div class="col-sm-2">
<div class="form-group row">

<div class="col-sm-12">
<asp:TextBox autocomplete="off" ID="FrieghtCRUEI" placeholder="CRUEI" Width="170" runat="server" ValidationGroup="FREIGHT" TabIndex="43" type="text"></asp:TextBox>
<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="FrieghtCRUEI" ID="RegularExpressionValidator20" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="FREIGHT"></asp:RegularExpressionValidator>
</div>
</div>

</div>
<div class="col-sm-3">
<div class="form-group row">

<div class="col-sm-12">
<asp:TextBox autocomplete="off" ID="FrieghtName" placeholder="Name" Width="275" runat="server" ValidationGroup="FREIGHT" TabIndex="44" type="text"></asp:TextBox>
<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="FrieghtName" ID="RegularExpressionValidator16" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="FREIGHT"></asp:RegularExpressionValidator>
</div>
</div>

</div>
<div class="col-sm-3">
<div class="form-group row">

<div class="col-sm-12">
<asp:TextBox autocomplete="off" ID="FrieghtName1" placeholder="Name1" Width="275" runat="server" ValidationGroup="FREIGHT" TabIndex="45" type="text"></asp:TextBox>
<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="FrieghtName1" ID="RegularExpressionValidator17" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="FREIGHT"></asp:RegularExpressionValidator>
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
Consignee
</div>
<div class="col-sm-4">
<asp:ImageButton ID="btntransconsignee" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" Style="margin-top: -250px;" />

<asp:Button ID="ConsigneeAdd" CssClass="plusbtn" BackColor="Transparent" BorderWidth="0px" Font-Size="Small" runat="server" ValidationGroup="CLAIMANT" OnClick="ConsigneeAdd_Click" Text="+" />
</div>
</div>


<%-- <i class='fa fa-search' data-toggle="modal" data-target="#CONSIGNEE"></i>--%>


</label>
<cc1:ModalPopupExtender ID="popuptransconsignee" runat="server" PopupControlID="pnltransconsignee" TargetControlID="btntransconsignee"
OkControlID="btnYestransconsignee" CancelControlID="btnNotransconsignee" BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>

<asp:Panel ID="pnltransconsignee" runat="server" CssClass="modalPopup" Style="display: none">
<div class="header">
CONSIGNEE
</div>
<div class="body">
<asp:UpdatePanel ID="uptransconsignee" runat="server" UpdateMode="Conditional">
<ContentTemplate>
<asp:TextBox autocomplete="off" ID="ConsigneeSearch" OnTextChanged="ConsigneeSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
<br />
<asp:GridView ID="ConsigneeGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="ConsigneeGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" OnRowCommand="ConsigneeGrid_RowCommand" OnRowDataBound="ConsigneeGrid_RowDataBound" AutoGenerateColumns="false">
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
<asp:TemplateField HeaderText="Sub Contry" SortExpression="Id" Visible="false">
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
<asp:TemplateField HeaderText="City" SortExpression="Id">
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



</asp:UpdatePanel>
</div>
<div class="footer" align="right">
<asp:Button ID="btnYestransconsignee" runat="server" Text="Yes" CssClass="yes" />
<asp:Button ID="btnNotransconsignee" runat="server" Text="No" CssClass="no" />
</div>
</asp:Panel>
<div class="col-sm-4">
<asp:TextBox autocomplete="off" runat="server" Width="100" placeholder="Code" OnTextChanged="ConsigneeCode_TextChanged" AutoPostBack="true" type="text" ID="ConsigneeCode" TabIndex="46"></asp:TextBox>
<br />
<br />
<cc1:AutoCompleteExtender ServiceMethod="GetCosigncode"
MinimumPrefixLength="1"
CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
TargetControlID="ConsigneeCode"
ID="AutoCompleteExtender9" runat="server" FirstRowSelected="true">
</cc1:AutoCompleteExtender>
</div>
</div>

</div>
<div class="col-sm-2">
<div class="form-group row">

<div class="col-sm-12">
<asp:TextBox autocomplete="off" ID="ConsigneeCRUEI" placeholder="CRUEI" Width="170" runat="server" ValidationGroup="consignee" TabIndex="47" type="text"></asp:TextBox>
<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeCRUEI" ID="RegularExpressionValidator68" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="consignee"></asp:RegularExpressionValidator>
</div>
<br />
<br />
<div class="col-sm-12">
<asp:TextBox autocomplete="off" ID="ConsigneeAddress" placeholder="Address" Width="170" runat="server" ValidationGroup="consignee" TabIndex="50" type="text"></asp:TextBox>
<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeAddress" ID="RegularExpressionValidator23" ValidationExpression="^[\s\S]{0,160}$" runat="server" ErrorMessage="Maximum 160 characters allowed." ValidationGroup="consignee"></asp:RegularExpressionValidator>
</div>
<br />
<br />
<div class="col-sm-12">
<asp:TextBox autocomplete="off" ID="ConsigneeSub" placeholder="Sub" Width="170" runat="server" ValidationGroup="consignee" TabIndex="53" type="text"></asp:TextBox>
<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeSub" ID="RegularExpressionValidator26" ValidationExpression="^[\s\S]{0,9}$" runat="server" ErrorMessage="Maximum 9 characters allowed." ValidationGroup="consignee"></asp:RegularExpressionValidator>
</div>
<br />
<br />
<div class="col-sm-12">
<asp:TextBox autocomplete="off" ID="ConsigneeSubDivi" placeholder="SubDivi" Width="170" runat="server" ValidationGroup="consignee" TabIndex="56" type="text"></asp:TextBox>
<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeSub" ID="RegularExpressionValidator48" ValidationExpression="^[\s\S]{0,9}$" runat="server" ErrorMessage="Maximum 9 characters allowed." ValidationGroup="consignee"></asp:RegularExpressionValidator>
</div>
</div>

</div>
<div class="col-sm-3">
<div class="form-group row">
<div class="col-sm-12">
<asp:TextBox autocomplete="off" runat="server" Width="275" placeholder="Con Name" ValidationGroup="consignee" type="text" ID="ConsigneeName" TabIndex="48"></asp:TextBox>
<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeName" ID="RegularExpressionValidator21" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="consignee"></asp:RegularExpressionValidator>
</div>
<br />
<br />
<div class="col-sm-12">
<asp:TextBox autocomplete="off" ID="ConsigneeAddress1" Width="275" placeholder="Con Address" runat="server" ValidationGroup="consignee" TabIndex="51" type="text"></asp:TextBox>
<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeAddress1" ID="RegularExpressionValidator24" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="consignee"></asp:RegularExpressionValidator>
</div>

<br />
<br />
<div class="col-sm-12">
<asp:TextBox autocomplete="off" ID="ConsigneePostal" Width="275" runat="server" placeholder="Con Postal" ValidationGroup="consignee" TabIndex="54" type="text"></asp:TextBox>
<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneePostal" ID="RegularExpressionValidator27" ValidationExpression="^[\s\S]{0,9}$" runat="server" ErrorMessage="Maximum 9 characters allowed." ValidationGroup="consignee"></asp:RegularExpressionValidator>
</div>
</div>

</div>
<div class="col-sm-3">
<div class="form-group row">
<div class="col-sm-12">
<asp:TextBox autocomplete="off" ID="ConsigneeName1" Width="275" runat="server" placeholder="Con Name1" ValidationGroup="consignee" TabIndex="49" type="text"></asp:TextBox>
<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeName1" ID="RegularExpressionValidator22" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="consignee"></asp:RegularExpressionValidator>
</div>
<br />
<br />
<div class="col-sm-12">
<asp:TextBox autocomplete="off" ID="ConsigneeCity" Width="275" runat="server" placeholder="City" ValidationGroup="consignee" TabIndex="52" type="text"></asp:TextBox>
<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeCity" ID="RegularExpressionValidator25" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="consignee"></asp:RegularExpressionValidator>
</div>

<br />
<br />
<div class="col-sm-12">
<asp:TextBox autocomplete="off" ID="ConsigneeCountry" Width="275" placeholder="Country" runat="server" ValidationGroup="consignee" TabIndex="55" type="text"></asp:TextBox>
<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeCountry" ID="RegularExpressionValidator28" ValidationExpression="^[\s\S]{0,2}$" runat="server" ErrorMessage="Maximum 2 characters allowed." ValidationGroup="consignee"></asp:RegularExpressionValidator>
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
End User
</div>
<div class="col-sm-4">
<asp:ImageButton ID="btntransenduser" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" Style="margin-top: -250px;" />

<asp:Button ID="EndUserAdd" CssClass="plusbtn" BackColor="Transparent" BorderWidth="0px" Font-Size="Small" runat="server" ValidationGroup="CLAIMANT" OnClick="EndUserAdd_Click" Text="+" />
</div>
</div>





</label>
<cc1:ModalPopupExtender ID="popuptransenduser" runat="server" PopupControlID="pnltransenduser" TargetControlID="btntransenduser"
OkControlID="btnYestransenduser" CancelControlID="btnNotransenduser" BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>

<asp:Panel ID="pnltransenduser" runat="server" CssClass="modalPopup" Style="display: none">
<div class="header">
End User
</div>
<div class="body">
<asp:UpdatePanel ID="uptransenduser" runat="server" UpdateMode="Conditional">
<ContentTemplate>
<asp:TextBox autocomplete="off" ID="EndUserSearch" OnTextChanged="EndUserSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
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
<asp:TemplateField HeaderText="Sub Contry" SortExpression="Id" Visible="false">
<ItemTemplate>
<asp:Label ID="ConsigneeSub" runat="server"
Text='<%#Eval("EndUserSub")%>'>
</asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Sub Division" SortExpression="Id" Visible="false">
<ItemTemplate>
<asp:Label ID="ConsigneeSubDivi" runat="server"
Text='<%#Eval("EndUserSubDivi")%>'>
</asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="City" SortExpression="Id" Visible="false">
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



</asp:UpdatePanel>
</div>
<div class="footer" align="right">
<asp:Button ID="btnYestransenduser" runat="server" Text="Yes" CssClass="yes" />
<asp:Button ID="btnNotransenduser" runat="server" Text="No" CssClass="no" />
</div>
</asp:Panel>
<div class="col-sm-4">
<asp:TextBox autocomplete="off" runat="server" Width="100" placeholder="Code" OnTextChanged="EndUserCode_TextChanged" AutoPostBack="true" type="text" ID="EndUserCode" TabIndex="57"></asp:TextBox>
<br />
<br />

<cc1:AutoCompleteExtender ServiceMethod="GetEnduser"
MinimumPrefixLength="1"
CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
TargetControlID="EndUserCode"
ID="AutoCompleteExtender7" runat="server" FirstRowSelected="true">
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
<asp:TextBox autocomplete="off" ID="EndUserCrueo" placeholder="CRUEI" Width="170" ValidationGroup="Enduser" runat="server" TabIndex="58" type="text"></asp:TextBox>
<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="EndUserCrueo" ID="RegularExpressionValidator31" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Enduser"></asp:RegularExpressionValidator>
</div>
<br />
<br />
<div class="col-sm-12">
<asp:TextBox autocomplete="off" ID="EndUserAddress" placeholder="Address" Width="170" ValidationGroup="Enduser" runat="server" TabIndex="61" type="text"></asp:TextBox>
<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="EndUserAddress" ID="RegularExpressionValidator32" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35characters allowed." ValidationGroup="Enduser"></asp:RegularExpressionValidator><br />
</div>
<br />
<br />
<div class="col-sm-12">
<asp:TextBox autocomplete="off" ID="EndUserSubCode" placeholder="Sub Code" Width="170" ValidationGroup="Enduser" runat="server" TabIndex="64" type="text"></asp:TextBox>
<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="EndUserSubCode" ID="RegularExpressionValidator35" ValidationExpression="^[\s\S]{0,9}$" runat="server" ErrorMessage="Maximum 9 characters allowed." ValidationGroup="Enduser"></asp:RegularExpressionValidator>
</div>
<br />
<br />
<div class="col-sm-12">
<asp:TextBox autocomplete="off" ID="EndUserSubCodeDivi" placeholder="Sub Divi" Width="170" ValidationGroup="Enduser" runat="server" TabIndex="67" type="text"></asp:TextBox>
<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="EndUserSubCode" ID="RegularExpressionValidator49" ValidationExpression="^[\s\S]{0,9}$" runat="server" ErrorMessage="Maximum 9 characters allowed." ValidationGroup="Enduser"></asp:RegularExpressionValidator>
</div>
</div>

</div>
<div class="col-sm-3">
<div class="form-group row">
<div class="col-sm-12">
<asp:TextBox autocomplete="off" runat="server" Width="275" type="text" placeholder="End Name" ValidationGroup="Enduser" ID="EndUserName" TabIndex="59"></asp:TextBox>
<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="EndUserName" ID="RegularExpressionValidator29" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="Enduser"></asp:RegularExpressionValidator><br />
</div>
<br />
<br />
<div class="col-sm-12">
<asp:TextBox autocomplete="off" ID="EndUserAddress1" Width="275" placeholder="Address1" ValidationGroup="Enduser" runat="server" TabIndex="62" type="text"></asp:TextBox>
<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="EndUserAddress1" ID="RegularExpressionValidator33" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35characters allowed." ValidationGroup="Enduser"></asp:RegularExpressionValidator><br />
</div>

<br />
<br />
<div class="col-sm-12">
<asp:TextBox autocomplete="off" ID="EndUserPostal" placeholder="Postal" Width="275" ValidationGroup="Enduser" runat="server" TabIndex="65" type="text"></asp:TextBox>
<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="EndUserPostal" ID="RegularExpressionValidator46" ValidationExpression="^[\s\S]{0,9}$" runat="server" ErrorMessage="Maximum 9 characters allowed." ValidationGroup="Enduser"></asp:RegularExpressionValidator>
</div>
</div>

</div>
<div class="col-sm-3">
<div class="form-group row">
<div class="col-sm-12">
<asp:TextBox autocomplete="off" ID="EndUserName1" placeholder="Name1" Width="275" ValidationGroup="Enduser" runat="server" TabIndex="60" type="text"></asp:TextBox>
<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="EndUserName1" ID="RegularExpressionValidator30" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="Enduser"></asp:RegularExpressionValidator>
</div>
<br />
<br />
<div class="col-sm-12">
<asp:TextBox autocomplete="off" ID="EndUserCity" placeholder="City" Width="275" ValidationGroup="Enduser" runat="server" TabIndex="63" type="text"></asp:TextBox>
<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="EndUserCity" ID="RegularExpressionValidator34" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Enduser"></asp:RegularExpressionValidator>
</div>
<br />
<br />
<div class="col-sm-12">
<asp:TextBox autocomplete="off" ID="EndUserCountry" placeholder="Country" Width="275" ValidationGroup="Enduser" runat="server" TabIndex="66" type="text"></asp:TextBox>
<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="EndUserCountry" ID="RegularExpressionValidator47" ValidationExpression="^[\s\S]{0,2}$" runat="server" ErrorMessage="Maximum 2 characters allowed." ValidationGroup="Enduser"></asp:RegularExpressionValidator><br />
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

<div class ="row">
<div id="location" runat="server" class="col-sm-6">
<div class="row Borderdiv" style="width: 100%">
Location Details
</div>
<br />
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Release Location&nbsp;
<asp:ImageButton ID="btntransreleaselocation" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" Style="margin-top: -250px;" />

</label>
<cc1:ModalPopupExtender ID="popuptransreleaseloc" runat="server" PopupControlID="pnltransreleaseloc" TargetControlID="btntransreleaselocation"
OkControlID="btnyestransrel" CancelControlID="btnnotransrel" BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>

<asp:Panel ID="pnltransreleaseloc" runat="server" CssClass="modalPopup" Style="display: none">
<div class="header">
Release Location
</div>
<div class="body">
<asp:UpdatePanel ID="uptransreleaseloc" runat="server" UpdateMode="Conditional">
<ContentTemplate>
<asp:TextBox autocomplete="off" ID="LocationSearch" OnTextChanged="LocationSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
<br />
<asp:GridView ID="LocationGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="LocationGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" OnRowCommand="LocationGrid_RowCommand" OnRowDataBound="LocationGrid_RowDataBound" runat="server" AutoGenerateColumns="false">
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



</asp:UpdatePanel>
</div>
<div class="footer" align="right">
<asp:Button ID="btnyestransrel" runat="server" Text="Yes" CssClass="yes" />
<asp:Button ID="btnnotransrel" runat="server" Text="No" CssClass="no" />
</div>
</asp:Panel>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" runat="server" Width ="100" ValidationGroup="Validation" BackColor="#e8f0fe" type="text" ID="txtreLoctn" OnTextChanged="txtreLoctn_TextChanged" AutoPostBack="true" TabIndex="72"></asp:TextBox>
<cc1:AutoCompleteExtender ServiceMethod="Getrelloc"
MinimumPrefixLength="1"
CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
TargetControlID="txtreLoctn"
ID="AutoCompleteExtender8" runat="server" FirstRowSelected="true">
</cc1:AutoCompleteExtender>
<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtreLoctn" ID="RegularExpressionValidator38" ValidationExpression="^[\s\S]{0,7}$" runat="server" ErrorMessage="Maximum 7 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
<asp:TextBox autocomplete="off" runat="server" type="text" Width="350" Style="text-transform:uppercase" TextMode = "MultiLine" MaxLength="256"  ValidationGroup="Validation"  ID="txtrelocDeta" TabIndex="73"></asp:TextBox>
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtrelocDeta" ID="RegularExpressionValidator39" ValidationExpression="^[\s\S]{0,256}$" runat="server" ErrorMessage="Maximum 256 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
</div>
</div>
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Receipt Location&nbsp;
<asp:ImageButton ID="btntransrecloc" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" Style="margin-top: -250px;" />

</label>
<cc1:ModalPopupExtender ID="popuptransrecloc" runat="server" PopupControlID="pnltransrecloc" TargetControlID="btntransrecloc"
OkControlID="btnYestransrecloc" CancelControlID="btnNotransrecloc" BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>

<asp:Panel ID="pnltransrecloc" runat="server" CssClass="modalPopup" Style="display: none">
<div class="header">
Receipt Location
</div>
<div class="body">
<asp:UpdatePanel ID="uptransrecloc" runat="server" UpdateMode="Conditional">
<ContentTemplate>
<asp:TextBox autocomplete="off" ID="ReceiptSearch" OnTextChanged="ReceiptSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
<br />
<asp:GridView ID="ReceiptGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="ReceiptGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" OnRowCommand="ReceiptGrid_RowCommand" OnRowDataBound="ReceiptGrid_RowDataBound" runat="server" AutoGenerateColumns="false">
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
<Triggers>
<asp:PostBackTrigger ControlID="ReceiptGrid" />
</Triggers>


</asp:UpdatePanel>
</div>
<div class="footer" align="right">
<asp:Button ID="btnYestransrecloc" runat="server" Text="Yes" CssClass="yes" />
<asp:Button ID="btnNotransrecloc" runat="server" Text="No" CssClass="no" />
</div>
</asp:Panel>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" runat="server" BackColor="#e8f0fe" ValidationGroup="Validation" Width ="100" type="text" OnTextChanged="txtrecloctn_TextChanged" AutoPostBack="true" ID="txtrecloctn" TabIndex="74"></asp:TextBox>

<cc1:AutoCompleteExtender ServiceMethod="GetRecLoc"
MinimumPrefixLength="1"
CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
TargetControlID="txtrecloctn"
ID="AutoCompleteExtender10" runat="server" FirstRowSelected="true">
</cc1:AutoCompleteExtender>
<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtrecloctn" ID="RegularExpressionValidator40" ValidationExpression="^[\s\S]{0,7}$" runat="server" ErrorMessage="Maximum 7 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
<asp:TextBox autocomplete="off" Style="text-transform:uppercase" TextMode = "MultiLine" runat="server" type="text" ValidationGroup="Validation" Width ="350" MaxLength="256" ID="txtrecloctndet" TabIndex="75"></asp:TextBox>
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtrecloctndet" ID="RegularExpressionValidator41" ValidationExpression="^[\s\S]{0,250}$" runat="server" ErrorMessage="Maximum 250 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
</div>
</div>
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Storage Location&nbsp;
<asp:ImageButton ID="btntransstorageloc" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" Style="margin-top: -250px;" />

</label>
<cc1:ModalPopupExtender ID="popuptransstorage" runat="server" PopupControlID="pnltransstorage" TargetControlID="btntransstorageloc"
OkControlID="btnYestransstorage" CancelControlID="btnNotransstorage" BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>

<asp:Panel ID="pnltransstorage" runat="server" CssClass="modalPopup" Style="display: none">
<div class="header">
Storage Location
</div>
<div class="body">
<asp:UpdatePanel ID="uptransstorage" runat="server" UpdateMode="Conditional">
<ContentTemplate>
<asp:TextBox autocomplete="off" ID="StorageSearch" OnTextChanged="StorageSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
<br />
<asp:GridView ID="StorageGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="StorageGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" OnRowCommand="StorageGrid_RowCommand" OnRowDataBound="StorageGrid_RowDataBound" AutoGenerateColumns="false">
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
<asp:LinkButton ID="LnkStorage" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LnkStorage_Command">Select </asp:LinkButton>
</ItemTemplate>
</asp:TemplateField>
</Columns>
</asp:GridView>
</ContentTemplate>
<Triggers>
<asp:PostBackTrigger ControlID="StorageGrid" />
</Triggers>


</asp:UpdatePanel>
</div>
<div class="footer" align="right">
<asp:Button ID="btnYestransstorage" runat="server" Text="Yes" CssClass="yes" />
<asp:Button ID="btnNotransstorage" runat="server" Text="No" CssClass="no" />
</div>
</asp:Panel>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" runat="server" ValidationGroup="Validation" Width ="100" type="text" OnTextChanged="TxtStorageShort_TextChanged" AutoPostBack="true" ID="TxtStorageShort" TabIndex="76"></asp:TextBox>
<cc1:AutoCompleteExtender ServiceMethod="GetStorageLoc"
MinimumPrefixLength="1"
CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
TargetControlID="TxtStorageShort"
ID="AutoCompleteExtender14" runat="server" FirstRowSelected="true">
</cc1:AutoCompleteExtender>
    <br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtStorageShort" ID="RegularExpressionValidator42" ValidationExpression="^[\s\S]{0,7}$" runat="server" ErrorMessage="Maximum 7 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
<%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator63" runat="server" ControlToValidate="TxtStorageShort" Display="None" ErrorMessage="Cargo -->Receipt Location Code is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>--%>
<asp:TextBox autocomplete="off" Style="text-transform:uppercase" TextMode = "MultiLine" runat="server" type="text" ID="TxtStorageName" ValidationGroup="Validation" Width ="350" MaxLength="256" TabIndex="77"></asp:TextBox>
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtStorageName" ID="RegularExpressionValidator43" ValidationExpression="^[\s\S]{0,250}$" runat="server" ErrorMessage="Maximum 250 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
</div>
</div>
<div class="form-group row">
<label for="staticEmail" id="lblrem" runat="server" class="col-sm-3 col-form-label">
Removal Start Date
</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" ID="BlankDate1" Style="width: 250px;" onkeypress="return noAlphabets(event)" Visible="false" runat="server" TabIndex="78" AutoPostBack="true" OnTextChanged="BlankDate1_TextChanged"></asp:TextBox>
<cc1:CalendarExtender ID="CalendarExtender1" PopupButtonID="imgPopup" runat="server" TargetControlID="BlankDate1" Enabled="true" Format="dd/MM/yyyy" ClientIDMode="Inherit"></cc1:CalendarExtender>
</div>
</div>
</div>
<div id="totalout" runat="server" class="col-sm-6">
<div class="row Borderdiv" style="width: 100%">
Outward Pack Details
</div>
<br />
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Total Outer Pack
</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" runat="server" onkeypress="return noAlphabets(event)"  type="text" BackColor="#e8f0fe" ValidationGroup="outerpack" ID="TxttotalOuterPack" TabIndex="79" OnTextChanged ="TxttotalOuterPack_TextChanged" AutoPostBack ="true" ></asp:TextBox>
<asp:DropDownList CssClass="drop" BackColor="#e8f0fe" ID="DrptotalOuterPack" runat="server" TabIndex="80" Width="100" Height="26" OnSelectedIndexChanged ="DrptotalOuterPack_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxttotalOuterPack" ID="RegularExpressionValidator44" ValidationExpression="^[\s\S]{0,8}$" runat="server" ErrorMessage="Maximum 8 characters allowed." ValidationGroup="outerpack"></asp:RegularExpressionValidator>
</div>
</div>
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Total Gross Weight
</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" runat="server" onkeypress="return noAlphabets(event)" BackColor="#e8f0fe" type="text" OnTextChanged ="TxtTotalGrossWeight_TextChanged" AutoPostBack ="true" ValidationGroup="outerpack" ID="TxtTotalGrossWeight" TabIndex="81" ></asp:TextBox>
<asp:DropDownList CssClass="drop" BackColor="#e8f0fe" ID="DrpTotalGrossWeight" OnSelectedIndexChanged ="DrpTotalGrossWeight_SelectedIndexChanged" AutoPostBack ="true" runat="server" Width="100" TabIndex="82" Height="26">
<asp:ListItem Selected="True" Text="--Select--" Value="--SELECT--"> </asp:ListItem>
<asp:ListItem Selected="false" Text="KGM" Value="KGM"> </asp:ListItem>
<asp:ListItem Selected="false" Text="TNE" Value="TNE"> </asp:ListItem>

</asp:DropDownList>
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtTotalGrossWeight" ID="RegularExpressionValidator45a" ValidationExpression="^[\s\S]{0,15}$" runat="server" ErrorMessage="Maximum 15 characters allowed." ValidationGroup="outerpack"></asp:RegularExpressionValidator>
</div>
</div>


</div>
</div>
<div class="row" runat ="server" >

<div id="InwardDetailsdiv1" runat="server" class="col-sm-6" visible="false">
<div class="row Borderdiv" style="width: 100%">
Inward Details
</div>
<br />
<div id="carMode" runat="server" class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Mode
</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" Enabled="false" BackColor="#e8f0fe" Style="width: 250px;" runat="server" type="text" ID="TextMode" OnTextChanged="TextMode_TextChanged" AutoPostBack="true" TabIndex="83"></asp:TextBox>
</div>
</div>
<div id="carArrival" runat="server" class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Arrival Date & Time
</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" onkeypress="return noAlphabets(event)" ID="TxtArrivalDate1" BackColor="#e8f0fe" Style="width:250px;" runat="server" AutoPostBack="true" TabIndex="84" OnTextChanged="TxtArrivalDate1_TextChanged"></asp:TextBox>
<cc1:CalendarExtender ID="CalendarExtender2" PopupButtonID="imgPopup" runat="server" TargetControlID="TxtArrivalDate1" Enabled="true" Format="dd/MM/yyyy" ClientIDMode="Inherit"></cc1:CalendarExtender>

</div>
</div>
<div id="carLoadingPort" runat="server">
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Loading Port&nbsp;&nbsp;&nbsp;&nbsp;
<asp:ImageButton ID="btntransloadingport" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" Style="margin-top: -250px;" />

</label>
<cc1:ModalPopupExtender ID="popuptransloadingport" runat="server" PopupControlID="pnltransloadingport" TargetControlID="btntransloadingport"
OkControlID="btnYestransloadingport" CancelControlID="btnNotransloadingport" BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>

<asp:Panel ID="pnltransloadingport" runat="server" CssClass="modalPopup" Style="display: none">
<div class="header">
Loading Port
</div>
<div class="body">
<asp:UpdatePanel ID="uptransloadingport" runat="server" UpdateMode="Conditional">
<ContentTemplate>
<asp:TextBox autocomplete="off" ID="CarLoadingSearch" OnTextChanged="CarLoadingSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
<br />
<asp:GridView ID="LoadingGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="LoadingGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" OnRowCommand="LoadingGrid_RowCommand" OnRowDataBound="LoadingGrid_RowDataBound" AutoGenerateColumns="false">
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


</asp:UpdatePanel>
</div>
<div class="footer" align="right">
<asp:Button ID="btnYestransloadingport" runat="server" Text="Yes" CssClass="yes" />
<asp:Button ID="btnNotransloadingport" runat="server" Text="No" CssClass="no" />
</div>
</asp:Panel>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" runat="server" BackColor="#e8f0fe" Width="75" type="text" ID="TxtLoadShort" OnTextChanged="TxtLoadShort_TextChanged" AutoPostBack="true" TabIndex="85"></asp:TextBox>
<cc1:AutoCompleteExtender ServiceMethod="GetLoadingport"
MinimumPrefixLength="1"
CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
TargetControlID="TxtLoadShort"
ID="AutoCompleteExtender15" runat="server" FirstRowSelected="true">
</cc1:AutoCompleteExtender>


<asp:TextBox autocomplete="off" Style="width: 175px;" Enabled="false" runat="server" type="text" ID="TxtLoad" TabIndex="86"></asp:TextBox>
</div>
</div>
</div>
<div id="InwardFlight" runat="server">
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Flight Number
</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" runat="server" Style="width: 250px;" BackColor="#e8f0fe" type="text" ID="txtflight" TabIndex="87"></asp:TextBox>

</div>
</div>
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Aircraft Register Number
</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" Style="width: 250px;" runat="server" type="text" ID="txtaircraft" TabIndex="88"></asp:TextBox>
</div>
</div>
<div id="inmaster" runat="server">
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Master Air Waybill
</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" Style="width: 250px;" runat="server" BackColor="#e8f0fe" OnTextChanged ="txtwaybill_TextChanged" AutoPostBack ="true" type="text" ID="txtwaybill" TabIndex="89"></asp:TextBox>

</div>
</div>
</div>
</div>
<div id="InwardSea" runat="server">
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Voyage Number
</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" Style="width: 250px;" runat="server" BackColor="#e8f0fe" ValidationGroup="Validation" type="text" ID="TxtVoyageno" TabIndex="90"></asp:TextBox>

<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtVoyageno" ID="RegularExpressionValidator102" ValidationExpression="^[\s\S]{0,15}$" runat="server" ErrorMessage="Maximum 15 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
</div>
</div>
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Vessel Name
</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" Style="width: 250px;" runat="server" BackColor="#e8f0fe" ValidationGroup="Validation" type="text" ID="TxtVesselName" TabIndex="91"></asp:TextBox>

<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtVesselName" ID="RegularExpressionValidator103" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
</div>
</div>
<div id="inobl" runat="server">
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
OBL
</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" Style="width: 250px;" runat="server" BackColor="#e8f0fe" OnTextChanged ="TxtOceanBill_TextChanged" AutoPostBack ="true" ValidationGroup="Validation" type="text" ID="TxtOceanBill" TabIndex="92"></asp:TextBox>

<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtOceanBill" ID="RegularExpressionValidator104" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
</div>
</div>
</div>
</div>
<div id="InwardOther" runat="server">
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Conveyance Ref.No
</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" Style="width: 250px;" runat="server" type="text" ID="TxtConRefNo" ValidationGroup="Validation" TabIndex="93"></asp:TextBox>
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtConRefNo" ID="RegularExpressionValidator106" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
</div>
</div>
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Transport ID
</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" Style="width: 250px;" runat="server" type="text" ID="TxtTrnsID" ValidationGroup="Validation" TabIndex="94"></asp:TextBox>
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtConRefNo" ID="RegularExpressionValidator107" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
</div>
</div>
</div>





</div>

<div runat="server" id="outtr" class="col-sm-6" visible="false">
<div class="row Borderdiv" style="width: 100%">
Outward Details
</div>
<br />
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Mode
</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" Style="width: 250px;" Enabled="false" BackColor="#e8f0fe" runat="server" type="text" ID="TxtExpMode" OnTextChanged="TxtExpMode_TextChanged" AutoPostBack="true" TabIndex="95"></asp:TextBox>
</div>
</div>
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Departure Date & Time
</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" ID="TxtExpArrivalDate1" onkeypress="return noAlphabets(event)" BackColor="#e8f0fe" Style="width:250px;" runat="server" AutoPostBack="true" TabIndex="96" OnTextChanged="TxtExpArrivalDate1_TextChanged"></asp:TextBox>
<cc1:CalendarExtender ID="CalendarExtender3" PopupButtonID="imgPopup" runat="server" TargetControlID="TxtExpArrivalDate1" Enabled="true" Format="dd/MM/yyyy" ClientIDMode="Inherit"></cc1:CalendarExtender>

</div>
</div>
<div id="dischargeport" runat="server">
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Discharge Port&nbsp;&nbsp;
<asp:ImageButton ID="btntransdischargeport" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" Style="margin-top: -250px;" />

</label>
<cc1:ModalPopupExtender ID="popuptransdischargeport" runat="server" PopupControlID="pnltransdischargeport" TargetControlID="btntransdischargeport"
OkControlID="btnYestransdischargeport" CancelControlID="btnNotransdischargeport" BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>

<asp:Panel ID="pnltransdischargeport" runat="server" CssClass="modalPopup" Style="display: none">
<div class="header">
Discharge Port
</div>
<div class="body">
<asp:UpdatePanel ID="uptransdischargeport" runat="server" UpdateMode="Conditional">
<ContentTemplate>
<asp:TextBox autocomplete="off" ID="ExpLoadingSearch" OnTextChanged="ExpLoadingSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
<br />
<asp:GridView ID="ExportGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="ExportGrid_PageIndexChanging" OnRowCommand="ExportGrid_RowCommand" OnRowDataBound="ExportGrid_RowDataBound" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
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
<Triggers>
<asp:PostBackTrigger ControlID="ExportGrid" />
</Triggers>


</asp:UpdatePanel>
</div>
<div class="footer" align="right">
<asp:Button ID="btnYestransdischargeport" runat="server" Text="Yes" CssClass="yes" />
<asp:Button ID="btnNotransdischargeport" runat="server" Text="No" CssClass="no" />
</div>
</asp:Panel>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" runat="server" BackColor="#e8f0fe" Width="75" type="text" ID="TxtExpLoadShort" OnTextChanged="TxtExpLoadShort_TextChanged" AutoPostBack="true" TabIndex="97"></asp:TextBox>
<cc1:AutoCompleteExtender ServiceMethod="GetDischargeport"
MinimumPrefixLength="1"
CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
TargetControlID="TxtExpLoadShort"
ID="AutoCompleteExtender16" runat="server" FirstRowSelected="true">
</cc1:AutoCompleteExtender>


<asp:TextBox autocomplete="off" Style="width: 175px;" runat="server" Enabled="false"  type="text" ID="TxtExpLoad" TabIndex="98"></asp:TextBox>
</div>
</div>


<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Final Destination Country
</label>
<div class="col-sm-9">
<asp:DropDownList CssClass="drop" Style="width: 250px;" BackColor="#e8f0fe" runat="server" ID="DrpFinalDesCountry" TabIndex="99"></asp:DropDownList>
</div>
</div>
</div>
<div id="Seastorediv" runat="server" visible="false">
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">Sea Store
</label>
<div class="col-sm-9">
<asp:CheckBox ID="chkSea" OnCheckedChanged="chkSea_CheckedChanged1" AutoPostBack="true" runat="server" TabIndex="100" />
</div>
</div>
</div>

<div id="OUTWARDFlight" runat="server">
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Flight Number
</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" Style="width: 250px;" runat="server" BackColor="#e8f0fe" type="text" ID="OUTWARDFlightN0" TabIndex="101"></asp:TextBox>

</div>
</div>
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Aircraft Register Number
</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" Style="width: 250px;" runat="server" type="text" ID="OUTWARDAirREgno" TabIndex="102"></asp:TextBox>
</div>
</div>
<div id="outmaster" runat="server">
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Master Air Waybill
</label>
<div class="col-sm-9"> 
<asp:TextBox autocomplete="off" Style="width: 250px;" runat="server" BackColor="#e8f0fe" OnTextChanged ="OUTWARDAirwaybill_TextChanged" AutoPostBack ="true" type="text" ID="OUTWARDAirwaybill" TabIndex="103"></asp:TextBox>

</div>
</div>
</div>
</div>
<div id="OUTWARDSea" runat="server">
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Voyage Number
</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" Style="width: 250px;" runat="server" BackColor="#e8f0fe" type="text" ID="OUTWARDVoyageNo" TabIndex="104"></asp:TextBox>

</div>
</div>
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Vessel Name
</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" Style="width: 250px;" runat="server" BackColor="#e8f0fe" type="text" ID="OUTWARDVessel" TabIndex="105"></asp:TextBox>

</div>
</div>
<div id="outobl" runat="server">
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
OBL
</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" Style="width: 250px;" runat="server" BackColor="#e8f0fe" OnTextChanged ="OUTWARDOcenbill_TextChanged" AutoPostBack ="true" type="text" ID="OUTWARDOcenbill" TabIndex="106"></asp:TextBox>

</div>
</div>
</div>
</div>
<div id="outvessel" runat="server">
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Vessel Type
</label>
<div class="col-sm-9">
<asp:DropDownList CssClass="drop" Style="width: 250px;" BackColor="#e8f0fe" ID="ddpVessel" runat="server" TabIndex="107"></asp:DropDownList>

</div>
</div>
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Vessel Net Register Tonnage
</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" Style="width: 250px;" runat="server" type="text" ID="txtvesnet" TabIndex="108"></asp:TextBox>
</div>
</div>
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Vessel Nationality
</label>
<div class="col-sm-9">
<asp:DropDownList CssClass="drop" Style="width: 250px;" runat="server" ID="DroVesslNat" TabIndex="109"></asp:DropDownList>
</div>
</div>
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Towing Vessel ID
</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" Style="width: 250px;" runat="server" type="text" ID="txtTowVes" TabIndex="110"></asp:TextBox>
</div>
</div>
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Towing Vessel Name
</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" Style="width: 250px;" runat="server" type="text" ID="txtTowVesName" TabIndex="111"></asp:TextBox>
</div>
</div>
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Next Port
<asp:ImageButton ID="btntransnxtport" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" Style="margin-top: -250px;" />

</label>
<cc1:ModalPopupExtender ID="popuptransnxtport" runat="server" PopupControlID="pnltransnxtport" TargetControlID="btntransnxtport"
OkControlID="btnYestransnxtport" CancelControlID="btnNotransnxtport" BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>

<asp:Panel ID="pnltransnxtport" runat="server" CssClass="modalPopup" Style="display: none">
<div class="header">
Next Port
</div>
<div class="body">
<asp:UpdatePanel ID="uptransnxtport" runat="server" UpdateMode="Conditional">
<ContentTemplate>
<asp:TextBox autocomplete="off" ID="NextPrtLoading" OnTextChanged="NextPrtLoading_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
<br />
<asp:GridView ID="NextPortGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="NextPortGrid_PageIndexChanging" OnRowCommand="NextPortGrid_RowCommand" OnRowDataBound="NextPortGrid_RowDataBound" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
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
<Triggers>
<asp:PostBackTrigger ControlID="NextPortGrid" />
</Triggers>


</asp:UpdatePanel>
</div>
<div class="footer" align="right">
<asp:Button ID="btnYestransnxtport" runat="server" Text="Yes" CssClass="yes" />
<asp:Button ID="btnNotransnxtport" runat="server" Text="No" CssClass="no" />
</div>
</asp:Panel>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" runat="server" Width="50px" type="text" ID="txtNextprt" AutoPostBack="true" OnTextChanged="txtNextprt_TextChanged" TabIndex="112"></asp:TextBox>
<cc1:AutoCompleteExtender ServiceMethod="GetNextport"
MinimumPrefixLength="1"
CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
TargetControlID="txtNextprt"
ID="AutoCompleteExtender17" runat="server" FirstRowSelected="true">
</cc1:AutoCompleteExtender>
<asp:TextBox autocomplete="off" Style="width: 200px;" Enabled="false" runat="server" type="text" ID="txtNetPrtSer" TabIndex="113"></asp:TextBox>
</div>
</div>
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Last Port
<asp:ImageButton ID="btntranslastport" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" Style="margin-top: -250px;" />

</label>
<cc1:ModalPopupExtender ID="popuptranslastport" runat="server" PopupControlID="pnltranslastport" TargetControlID="btntranslastport"
OkControlID="btnYestranslastport" CancelControlID="btnNotranslastport" BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>

<asp:Panel ID="pnltranslastport" runat="server" CssClass="modalPopup" Style="display: none">
<div class="header">
Last Port
</div>
<div class="body">
<asp:UpdatePanel ID="uptranslastport" runat="server" UpdateMode="Conditional">
<ContentTemplate>
<asp:TextBox autocomplete="off" ID="txtlastprt" OnTextChanged="txtlastprt_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
<br />
<asp:GridView ID="LastGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="LastGrid_PageIndexChanging" OnRowCommand="LastGrid_RowCommand" OnRowDataBound="LastGrid_RowDataBound" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
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
<asp:Button ID="btnYestranslastport" runat="server" Text="Yes" CssClass="yes" />
<asp:Button ID="btnNotranslastport" runat="server" Text="No" CssClass="no" />
</div>
</asp:Panel>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" runat="server" Width="50" type="text" ID="txtLasPrt" AutoPostBack="true" OnTextChanged="txtLasPrt_TextChanged" TabIndex="114"></asp:TextBox>
<cc1:AutoCompleteExtender ServiceMethod="GetLastport"
MinimumPrefixLength="1"
CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
TargetControlID="txtLasPrt"
ID="AutoCompleteExtender18" runat="server" FirstRowSelected="true">
</cc1:AutoCompleteExtender>
<asp:TextBox autocomplete="off" Style="width: 200px;" Enabled="false" runat="server" type="text" ID="txtLasPrtSer" TabIndex="115"></asp:TextBox>
</div>
</div>
</div>

<div id="OUTWARDOther" runat="server">
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Conveyance Ref.No
</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" Style="width: 250px;" runat="server" type="text" ID="OUTWARDConref" TabIndex="116"></asp:TextBox>
</div>
</div>
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Transport ID
</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" Style="width: 250px;" runat="server" type="text" ID="OUTWARDTransId" TabIndex="117"></asp:TextBox>
</div>
</div>
</div>

</div>
</div>
                              <div class="row">
                                                                            <div class="col-sm-12 text-center">

                                                                                <center>

                                                                                        <div id="gvAddrow" visible ="false"  runat ="server" >
                                                                                            <asp:GridView ID="ContarinerGrid" runat="server"  OnRowDeleting="ContarinerGrid_RowDeleting" OnRowDataBound="ContarinerGrid_RowDataBound1" ShowFooter="true" AutoGenerateColumns="false">
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
<div class="row">
<div class="col-sm-4">
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
<p id="inhab" runat="server" style="margin-left:-2px;">In HAWB/OBL</p>
<p id="phawb" visible="false" runat="server" style="margin-left:-2px;">HAWB</p>
<p id="inhbl" visible="false" runat="server" style="margin-left:-2px;">HBL</p>
</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" runat="server" ValidationGroup="Item" Width ="200" type="text" ID="TxtHAWB" OnTextChanged="TxtHAWB_TextChanged" AutoPostBack="true" TabIndex="127"></asp:TextBox>
<asp:Button ID="btnCopyAll" runat="server" Text="Copy All" Width="50"  OnClick="btnCopyAll_Click" />
<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator49" runat="server" ControlToValidate="TxtHAWB" ErrorMessage="Item--->Please Enter In HAWB/OBL"
Display="None" ValidationGroup="ItemMasterValidation" ForeColor="Red"></asp:RequiredFieldValidator>--%>
<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtHAWB" ID="RegularExpressionValidator57" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>


</div>
</div>
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Out HAWB/HBL
</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" runat="server" ValidationGroup="Item" type="text" ID="txtOutHAWB" Width ="200" OnTextChanged ="txtOutHAWB_TextChanged" AutoPostBack ="true" TabIndex="128"></asp:TextBox>
<asp:Button ID="BtnOutCopyAll" runat="server" Text="Copy All" Width="50" OnClick="BtnOutCopyAll_Click" />
<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator56" runat="server" ControlToValidate="txtOutHAWB" ErrorMessage="Item--->Please Enter Out HAWB/OBL"
Display="None" ValidationGroup="Item" ForeColor="Red"></asp:RequiredFieldValidator>--%>
<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtOutHAWB" ID="RegularExpressionValidator100" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>


</div>
</div>



<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Item Code
</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" ID="TxtInHouseItem" Width="275" AutoPostBack="true" OnTextChanged="TxtInHouseItem_TextChanged" runat="server" TabIndex="129" type="text"></asp:TextBox><br />
<cc1:AutoCompleteExtender ServiceMethod="GetInhouse"
MinimumPrefixLength="1"
CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
TargetControlID="TxtInHouseItem"
ID="AutoCompleteExtender11" runat="server" FirstRowSelected="true">
</cc1:AutoCompleteExtender>

<asp:Label ID="Label1" Visible="false" ForeColor="Red" BackColor="#ffff00" runat="server"></asp:Label>
<br />
<asp:Label ID="lbldhserror" Visible="false" ForeColor="Red" BackColor="#ffff00" runat="server"></asp:Label>
<br />
</div>
</div>
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
HS Code
</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" BackColor="#e8f0fe"  Width="275" ID="TxtHSCodeItem" ValidationGroup="Item" OnTextChanged="TxtHSCodeItem_TextChanged" AutoPostBack="true" runat="server" TabIndex="130" type="text"></asp:TextBox><br />

<cc1:AutoCompleteExtender ServiceMethod="GetHSCodeItem"
MinimumPrefixLength="1"
CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
TargetControlID="TxtHSCodeItem"
ID="AutoCompleteExtender12" runat="server" FirstRowSelected="true">
</cc1:AutoCompleteExtender>

<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtHSCodeItem" ID="RegularExpressionValidator54" ValidationExpression="^[\s\S]{0,8}$" runat="server" ErrorMessage="Maximum 10 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
<asp:Label ID="lblhserror" Visible="false" ForeColor="Red" BackColor="#ffff00" runat="server"></asp:Label>
</div>
</div>
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Description
</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" BackColor="#e8f0fe"  Width="275" ID="TxtDescription" ValidationGroup="Item" style="text-transform :uppercase " OnTextChanged="TxtDescription_TextChanged" AutoPostBack="true" TextMode="MultiLine" Height="75" runat="server" TabIndex="131" type="text"></asp:TextBox>
<br />

<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtDescription" ID="RegularExpressionValidator53" ValidationExpression="^[\s\S]{0,512}$" runat="server" ErrorMessage="Maximum 512 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
<asp:Label ID="LblCount" runat="server" TabIndex="5"></asp:Label>

</div>
</div>
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
COO&nbsp;
<asp:ImageButton ID="btntransorgin" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" Style="margin-top: -250px;" />

</label>
<cc1:ModalPopupExtender ID="popuptransorgin" runat="server" PopupControlID="pnltransorgin" TargetControlID="btntransorgin"
OkControlID="btnYestransorgin" CancelControlID="btnNotransorgin" BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>

<asp:Panel ID="pnltransorgin" runat="server" CssClass="modalPopup" Style="display: none">
<div class="header">
ORGIN OF COUNTRY
</div>
<div class="body">
<asp:UpdatePanel ID="uptransorgin" runat="server" UpdateMode="Conditional">
<ContentTemplate>
<asp:TextBox autocomplete="off" ID="CountrySearchItem" OnTextChanged="CountrySearchItem_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
<br />
<asp:GridView ID="CountryGridItem" OnPageIndexChanging="CountryGridItem_PageIndexChanging" PageSize="5" OnRowCommand="CountryGridItem_RowCommand" OnRowDataBound="CountryGridItem_RowDataBound" AllowPaging="True" DataKeyNames="Id" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
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
<Triggers>
<asp:PostBackTrigger ControlID="CountryGridItem" />
</Triggers>


</asp:UpdatePanel>
</div>
<div class="footer" align="right">
<asp:Button ID="btnYestransorgin" runat="server" Text="Yes" CssClass="yes" />
<asp:Button ID="btnNotransorgin" runat="server" Text="No" CssClass="no" />
</div>
</asp:Panel>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" Width="75" BackColor="#e8f0fe" ID="TxtCountryItem" OnTextChanged="TxtCountryItem_TextChanged" AutoPostBack="true" runat="server" TabIndex="132" type="text"></asp:TextBox>
<asp:TextBox autocomplete="off" ID="txtcname" runat="server" Width ="200" Enabled="false" TabIndex="133"></asp:TextBox>
<cc1:AutoCompleteExtender ServiceMethod="GetCountryItem"
MinimumPrefixLength="1"
CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
TargetControlID="TxtCountryItem"
ID="AutoCompleteExtender13" runat="server" FirstRowSelected="true">
</cc1:AutoCompleteExtender>

</div>
</div>
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
</label>
<div class="col-sm-9">
<asp:CheckBox ID="ChkBGIndicator" runat="server" Text="DG Indicator" TabIndex="134" />
<asp:CheckBox ID="ChkUnbrand" OnCheckedChanged="ChkUnbrand_CheckedChanged" AutoPostBack="true" runat="server" Text="Unbranded" TabIndex="135" />
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
<asp:TextBox autocomplete="off" ID="TxtBrand" runat="server"   Width="250" ValidationGroup="Item" TabIndex="136" type="text"></asp:TextBox>

<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtBrand" ID="RegularExpressionValidator55" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
</div>
</div>
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Model
</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" ID="TxtModel"  Width="250" runat="server" ValidationGroup="Item" TabIndex="137" type="text"></asp:TextBox>

<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtModel" ID="RegularExpressionValidator56" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
</div>
</div>
<div id="Vehicle" visible ="false" runat="server">
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">Vehicle Type</label>
<div class="col-sm-9">
<asp:DropDownList ID="DrpVehicleType"  Width="250" CssClass="drop" runat="server" Height="25" TabIndex="138"></asp:DropDownList>
</div>
</div>
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">Engine Capacity</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" runat="server" type="text" onkeypress="return noAlphabets(event)" Text="" ID="txtengine" width="75" TabIndex="97"></asp:TextBox>
<asp:DropDownList CssClass="drop" ID="DrpVehicleCapacity" runat="server" Width="175" Height="25" TabIndex="139"></asp:DropDownList>
</div>
</div>
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">Original Registration Date</label>
<div class="col-sm-9">


<asp:TextBox autocomplete="off" ID="OriginalRegDate" onkeypress="return noAlphabets(event)" Width="250" runat="server" AutoPostBack="true" TabIndex="140" OnTextChanged="OriginalRegDate_TextChanged"></asp:TextBox>
<cc1:CalendarExtender ID="CalendarExtender4" PopupButtonID="imgPopup" runat="server" TargetControlID="OriginalRegDate" Enabled="true" Format="dd/MM/yyyy" ClientIDMode="Inherit"></cc1:CalendarExtender>
</div>
</div>
</div>
<div id="totDuticableQtyDiv" runat="server" visible="false">
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">Duti Qty</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" runat="server" onkeypress="return noAlphabets(event)" ValidationGroup="Item" AutoPostBack="true" OnTextChanged="TxtTotalDutiableQuantity_TextChanged" Width ="100" type="text" Text="0.00" ID="TxtTotalDutiableQuantity" TabIndex="141"></asp:TextBox>
<asp:DropDownList CssClass="drop" ID="TDQUOM" runat="server" Width="150" Height="25" TabIndex="142"></asp:DropDownList>
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtTotalDutiableQuantity" ID="RegularExpressionValidator58" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
</div>
</div>


</div>
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">Ttl Duti Qty</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" onkeypress="return noAlphabets(event)" runat="server" type="text" ValidationGroup="Item" Width ="100" Text="0.00" ID="txttotDutiableQty" TabIndex="143"></asp:TextBox>
<asp:DropDownList CssClass="drop" ID="ddptotDutiableQty" runat="server" Width="150" Height="25" TabIndex="150"></asp:DropDownList>
</div>
</div>
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">INV Qty</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" runat="server" onkeypress="return noAlphabets(event)" Width="250" ValidationGroup="Item" type="text" Text="0.00" ID="TxtInvQty" OnTextChanged="TxtInvQty_TextChanged" AutoPostBack="true" TabIndex="144"></asp:TextBox>
<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtInvQty" ID="RegularExpressionValidator59" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>

<br />
<asp:Label runat="server" ID="lblinvqty" Visible="false" ForeColor="Red" BackColor="Yellow"></asp:Label>
</div>
</div>
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">Hs Qty</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" runat="server" BackColor="#e8f0fe" onkeypress="return noAlphabets(event)" ValidationGroup="Item" Width ="100" type="text" ID="TxtHSQuantity" TabIndex="145"></asp:TextBox>

<asp:DropDownList CssClass="drop" BackColor="#e8f0fe" ID="HSQTYUOM" runat="server" Width="150" OnSelectedIndexChanged="HSQTYUOM_SelectedIndexChanged" AutoPostBack="true" Height="25" TabIndex="146"></asp:DropDownList>
<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtHSQuantity" ID="RegularExpressionValidator62" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
<br />
<asp:Label ID="LblHSErr" ForeColor="Red" runat="server"></asp:Label>
</div>
</div>
<div id="AlcoholDiv" runat="server" visible="false">
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">Alcohol Percentage</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" runat="server" Width="250" onkeypress="return noAlphabets(event)" ValidationGroup="Item" type="text" Text="0.00" ID="txtAlcoholPer" TabIndex="147"></asp:TextBox>
</div>
</div>
</div>
    <div class="form-group row">
<div class="col-sm-3">
<asp:CheckBox ID="ChkPackInfo" OnCheckedChanged="ChkPackInfo_CheckedChanged" runat="server" AutoPostBack="true" Text="Packing Info" TabIndex="148" Width="150" Style="text-transform: uppercase" />
</div>
<div class="col-sm-3">
<asp:CheckBox ID="Chkitemcasc" runat="server" OnCheckedChanged="Chkitemcasc_CheckedChanged" AutoPostBack="true" Text="Item CASC" TabIndex="157" Width="150" Style="text-transform: uppercase" />
</div>
<div class="col-sm-3">
<asp:CheckBox ID="Chklot" runat="server" OnCheckedChanged="Chklot_CheckedChanged" AutoPostBack="true" Text="LOT Identification" TabIndex="186" Width="167" Style="text-transform: uppercase" />
</div>
<div class="col-sm-3">
<asp:CheckBox ID="ChkTariff" runat="server" OnCheckedChanged="ChkTariff_CheckedChanged" Visible="false" AutoPostBack="true" Text="Tariff" Width="151" Style="text-transform: uppercase" />
</div>

</div>
</div>

<div class="col-sm-4">
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Currency (Unit Price
<asp:CheckBox ID="ChkUnitPrice" CausesValidation="true" OnCheckedChanged="ChkUnitPrice_CheckedChanged" AutoPostBack="true" runat="server" TabIndex="190" />Auto )
</label>
<div class="col-sm-9">
<asp:DropDownList CssClass="drop" ID="DRPCurrency" BackColor="#e8f0fe" CausesValidation="true" OnSelectedIndexChanged="DRPCurrency_SelectedIndexChanged" TabIndex="191" AutoPostBack="true" runat="server" Width="100" Height="25"></asp:DropDownList>

<asp:TextBox autocomplete="off" ID="TxtExchangeRate" Enabled="false" Text="0.00" runat="server" Width="150" Height="25" TabIndex="192"></asp:TextBox>
</div>
</div>
<div id="OptionalCharges" visible ="false" runat="server">
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Optional Charges
</label>
<div class="col-sm-9">
<asp:DropDownList CssClass="drop" ID="DrpOptionalUom" CausesValidation="true" OnSelectedIndexChanged="DrpOptionalUom_SelectedIndexChanged" TabIndex="193" AutoPostBack="true" runat="server" Width="137" Height="25"></asp:DropDownList>

<asp:TextBox autocomplete="off" runat="server" Text="0.00" ID="TxtOptionalPrice" Enabled ="false" Width ="137" OnTextChanged="TxtOptionalPrice_TextChanged" AutoPostBack="true" TabIndex="194"></asp:TextBox>
</div>
</div>
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" ID="TxtOptionalExchageRate" TabIndex="195" Text="0.00" OnTextChanged ="TxtOptionalExchageRate_TextChanged" AutoPostBack="true" runat="server" Width="137" Height="25"></asp:TextBox>

<asp:TextBox autocomplete="off" runat="server" type="text" ID="TxtOptionalSumExRate" Width="137" TabIndex="196" Text="0.00"></asp:TextBox>
</div>
</div>
</div>
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Ttl Line Amt
</label>
<div class="col-sm-9">
<asp:Label ID="Lbl3" Font-Size="9" onkeypress="return noAlphabets(event)" Text="Total Line Amount" Visible="false" runat="server" ></asp:Label>

<asp:TextBox autocomplete="off" CausesValidation="true" BackColor="#e8f0fe" OnTextChanged="TxtTotalLineAmount_TextChanged" onkeypress="return noAlphabets(event)" Text="0.00" Width="250" AutoPostBack="true" runat="server" type="text" ID="TxtTotalLineAmount" TabIndex="197"></asp:TextBox>

</div>
</div>
<div class="form-group row">
<%-- <label for="staticEmail" class="col-sm-3 col-form-label">
Total INV Chrg(SGD)
</label>--%>
<div class="col-sm-9">
<asp:Label Font-Size="9" Text="Total Line Charges(SGD)" Visible="false" ID="Label3" runat="server" Width="100"></asp:Label>
<asp:TextBox autocomplete="off" runat="server" type="text" Width="275" ID="TxtTotalLineCharges" Visible="false" Text="0.00" TabIndex="198"></asp:TextBox>
</div>
</div>
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
CIF/FOB (SGD)
</label>
<div class="col-sm-9">
<asp:Label Font-Size="9" Text="CIF/FOB (SGD)" ID="Label4" runat="server" Width="100" Visible="false"></asp:Label>
<asp:TextBox autocomplete="off" runat="server" Width="275" type="text" ID="TxtCIFFOB" Text="0.00" TabIndex="199"></asp:TextBox>
</div>
</div>
<div id="OBLINOUT" runat="server" visible="false">

<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
In MAWB/OBL
</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" Width="275" BackColor="#e8f0fe" ID="TxtInMAWBOBL" OnTextChanged ="TxtInMAWBOBL_TextChanged" AutoPostBack ="true" runat="server" ValidationGroup="Item" TabIndex="200" type="text"></asp:TextBox>

<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtInMAWBOBL" ID="RegularExpressionValidator51" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
</div>
</div>

</div>

<div id="OBLOUTMAWBL" runat="server" visible="false">
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Out MAWB/OBL
</label>
<div class="col-sm-9">
<asp:TextBox autocomplete="off" Width="275" BackColor="#e8f0fe" ID="TxtOutMAWBOBL" OnTextChanged ="TxtOutMAWBOBL_TextChanged" AutoPostBack ="true" runat="server" ValidationGroup="Item" TabIndex="201" type="text"></asp:TextBox>

<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtOutMAWBOBL" ID="RegularExpressionValidator52" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
</div>
</div>


</div>




<div id="PackingInfo" visible="false" runat="server">
<div class="form-group row">
<label for="staticEmail" class="col-sm-4 col-form-label">
Outer Pack Qty
</label>
<div class="col-sm-8">
<asp:TextBox autocomplete="off" Width="100" runat="server" onkeypress="return noAlphabets(event)" Text="0" type="text" ValidationGroup="Item" ID="TxtOPQty" AutoPostBack="true" OnTextChanged="TxtOPQty_TextChanged" TabIndex="149"></asp:TextBox>
<asp:DropDownList CssClass="drop" Width="100" ID="DRPOPQUOM" runat="server"  Height="25" TabIndex="150"></asp:DropDownList>
<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtOPQty" ID="RegularExpressionValidator64" ValidationExpression="^[\s\S]{0,8}$" runat="server" ErrorMessage="Maximum 8 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
</div>
</div>
<div class="form-group row">
<label for="staticEmail" class="col-sm-4 col-form-label">
In Pack Qty
</label>
<div class="col-sm-8">
<asp:TextBox autocomplete="off" Width="100" runat="server" onkeypress="return noAlphabets(event)" Text="0" type="text" ValidationGroup="Item" AutoPostBack="true" OnTextChanged="TxtIPQty_TextChanged" ID="TxtIPQty" TabIndex="151"></asp:TextBox>
<asp:DropDownList CssClass="drop" ID="DRPIPQUOM" runat="server" Width="100" Height="25" TabIndex="152"></asp:DropDownList>
<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtIPQty" ID="RegularExpressionValidator63" ValidationExpression="^[\s\S]{0,8}$" runat="server" ErrorMessage="Maximum 8 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
</div>
</div>
<div class="form-group row">
<label for="staticEmail" class="col-sm-4 col-form-label">
Inner Pack Qty
</label>
<div class="col-sm-8">
<asp:TextBox autocomplete="off" Width="100" runat="server" onkeypress="return noAlphabets(event)" Text="0" type="text" ValidationGroup="Item" ID="TxtINPQty" OnTextChanged="TxtINPQty_TextChanged" AutoPostBack="true" TabIndex="153"></asp:TextBox>
<asp:DropDownList CssClass="drop" ID="DRPINNPQUOM" runat="server" Width="100" Height="25" TabIndex="154"></asp:DropDownList>
<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtINPQty" ID="RegularExpressionValidator65" ValidationExpression="^[\s\S]{0,8}$" runat="server" ErrorMessage="Maximum 8 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
</div>
</div>
<div class="form-group row">
<label for="staticEmail" class="col-sm-4 col-form-label">
Inmost Pack Qty
</label>
<div class="col-sm-8">
<%--<asp:TextBox autocomplete="off" Width="100" runat="server" onkeypress="return noAlphabets(event)" Text="0" type="text" ValidationGroup="Item" ID="TextBox4" OnTextChanged="TxtINPQty_TextChanged" AutoPostBack="true" TabIndex="155"></asp:TextBox>--%>
<asp:TextBox autocomplete="off" Width="100"  runat="server" Text="0" AutoPostBack="true" OnTextChanged="TxtIMPQty_TextChanged" onkeypress="return noAlphabets(event)" type="text" ValidationGroup="Item" ID="TxtIMPQty" TabIndex="156"></asp:TextBox>
<asp:DropDownList CssClass="drop" ID="DRPIMPQUOM" runat="server" Width="100" Height="25" TabIndex="175"></asp:DropDownList>

<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtIMPQty" ID="RegularExpressionValidator66" ValidationExpression="^[\s\S]{0,8}$" runat="server" ErrorMessage="Maximum 8 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
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
<asp:TextBox autocomplete="off" ID="InhouseSearchItem" OnTextChanged="InhouseSearchItem_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
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

<!-- Search -->
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
<asp:TextBox autocomplete="off" ID="HSCodeSearchItem" OnTextChanged="HSCodeSearchItem_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
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
<div id="SerItemDiv" runat="server" visible="false" class="row">
<div class="col-sm-12">
<asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True"
ShowSummary="False" ValidationGroup="Item" />
<p>Serial Number</p>
<asp:TextBox autocomplete="off" runat="server" Width="240" type="text" ID="TxtSerialNo" TabIndex="176"></asp:TextBox>

<br />




</div>


</div>

</div>
<div class="col-sm-4">
</div>

</div>
<div class="row">
<div class="col-sm-12">
<div class="row">
<div class="col-sm-12">
<asp:TextBox autocomplete="off" runat="server" Text="0.00" ID="TxtUnitPrice" OnTextChanged="TxtUnitPrice_TextChanged" AutoPostBack="true" Visible="false" ></asp:TextBox>
</div>
</div>
<div class="row">
<div class="col-sm-12">
<asp:TextBox autocomplete="off" runat="server" type="text" ID="TxtSumExRate" Text="0.00" Visible="false"></asp:TextBox>
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

<%--<asp:UpdatePanel ID="UpdatePanelProductCode1" runat="server" UpdateMode="Always">

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
<asp:TextBox autocomplete="off" ID="ProductCode1Search" OnTextChanged="ProductCode1Search_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server" Style="text-transform: uppercase"></asp:TextBox>




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



<asp:TextBox autocomplete="off" runat="server" type="text" ValidationGroup="Productcode" ID="TxtProductCode1" MaxLength="17" OnTextChanged="TxtProductCode1_TextChanged" AutoPostBack="true" TabIndex="158" Style="text-transform: uppercase"></asp:TextBox>
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProductCode1" ID="RegularExpressionValidator67" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>



<p>Quantity</p>


<asp:TextBox autocomplete="off" Width="100" onkeypress="return noAlphabets(event)" runat="server" type="text" ValidationGroup="Productcode" ID="TxtProQty1" MaxLength="16" Text="0.00" TabIndex="159"></asp:TextBox>


<asp:DropDownList CssClass="drop" ID="DrpP1" runat="server" Width="70" Height="25" TabIndex="160"></asp:DropDownList>

<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProQty1" ID="RegularExpressionValidator69" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>



</div>
</div>
</div>

<div class="col-sm-9">
<p style ="font-weight :bold ">End User Description</p>
<asp:TextBox autocomplete="off" Width="100%" runat="server" onchange="countChars(this);" type="text" ID="EndUserDesp1"   ValidationGroup="Productcode" style="text-transform :uppercase" TextMode="MultiLine" Text="" TabIndex="161"></asp:TextBox>
<br />
 <p id="charNum">0 characters</p>
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="EndUserDesp1" ID="RegularExpressionValidator78" ValidationExpression="^[\s\S]{0,256}$" runat="server" ErrorMessage="Maximum 256 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>


<br />



<asp:GridView CssClass="table table-striped table-bordered table-hover" ID="ProductCode1Grid1" runat="server" ShowFooter="true" AutoGenerateColumns="false">
<PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
<Columns>

<asp:BoundField DataField="RowNumber" HeaderText="Row Number" Visible="false" />

<asp:TemplateField HeaderText="CASC CODE 1">

<ItemTemplate>

<asp:TextBox autocomplete="off" ID="TextBox1" MaxLength="35" runat="server" TabIndex="162"></asp:TextBox>

</ItemTemplate>

</asp:TemplateField>

<asp:TemplateField HeaderText="CASC CODE 2">

<ItemTemplate>

<asp:TextBox autocomplete="off" ID="TextBox2" MaxLength="35" TabIndex="163" runat="server"></asp:TextBox>

</ItemTemplate>

</asp:TemplateField>

<asp:TemplateField HeaderText="CASC CODE 3">

<ItemTemplate>

<asp:TextBox autocomplete="off" ID="TextBox3" MaxLength="35" TabIndex="164" runat="server"></asp:TextBox>

</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="ADD">
<ItemTemplate>
<asp:Button ID="ProductCode1Add" OnClick="ProductCode1Add_Click" runat="server" Text="Add"  />
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
<div id="collapsep1d" class="panel-collapse collapse in ">
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


<%--<asp:UpdatePanel ID="UpdatePanelProductCode2" runat="server" UpdateMode="Always">

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
<p>Product Code &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnproductcode"  runat="server" Text="Search" /><%--<i class='fa fa-search' data-toggle="modal" data-target="#Product2"></i>--%></p>

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
<asp:TextBox autocomplete="off" ID="ProductCode2Search" OnTextChanged="ProductCode2Search_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
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

<asp:TextBox autocomplete="off" runat="server" type="text" ValidationGroup="Productcode" ID="TxtProductCode2" MaxLength="17" OnTextChanged="TxtProductCode2_TextChanged" AutoPostBack="true" TabIndex="124"></asp:TextBox>

<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProductCode2" ID="RegularExpressionValidator70" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>

<p>Quantity</p>
<asp:TextBox autocomplete="off" Width="70" runat="server" type="text" onkeypress="return noAlphabets(event)" ID="TxtProQty2" MaxLength="16" ValidationGroup="Productcode" TabIndex="125"></asp:TextBox>
<asp:DropDownList CssClass="drop" ID="DrpP2" runat="server" Width="70" Height="25" TabIndex="126"></asp:DropDownList>
<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProQty2" ID="RegularExpressionValidator71" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>


</div>
<div class="col-sm-9">


<p>End User Description</p>
<asp:TextBox autocomplete="off" Width="100%" runat="server" type="text" onchange="countChars1(this);" ID="EndUserDesp2" style="text-transform :uppercase" ValidationGroup="Productcode" TextMode="MultiLine" Text="" TabIndex="229"></asp:TextBox>
<br />
    <p id="end2">0 characters</p>
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="EndUserDesp2" ID="RegularExpressionValidator79" ValidationExpression="^[\s\S]{0,256}$" runat="server" ErrorMessage="Maximum 256 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>


<br />


<asp:GridView CssClass="table table-striped table-bordered table-hover" ID="ProductCode2Grid1" runat="server" ShowFooter="true" AutoGenerateColumns="false">
<PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
<Columns>

<asp:BoundField DataField="Product Code " HeaderText="Row Number" Visible="false" />

<asp:TemplateField HeaderText="CASC CODE 1">

<ItemTemplate>

<asp:TextBox autocomplete="off" ID="TextBox1" MaxLength="35" TabIndex="127" runat="server"></asp:TextBox>

</ItemTemplate>

</asp:TemplateField>

<asp:TemplateField HeaderText="CASC CODE 2">

<ItemTemplate>

<asp:TextBox autocomplete="off" ID="TextBox2" MaxLength="35" TabIndex="128" runat="server"></asp:TextBox>

</ItemTemplate>

</asp:TemplateField>

<asp:TemplateField HeaderText="CASC CODE 3">

<ItemTemplate>

<asp:TextBox autocomplete="off" ID="TextBox3" MaxLength="35" TabIndex="129" runat="server"></asp:TextBox>

</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="ADD">
<ItemTemplate>
<asp:Button ID="ProductCode2Add" OnClick="ProductCode2Add_Click" runat="server" Text="Add" />
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


   
</div>
</div>
<div class="row">
<div class="col-sm-3">

<p>Product Code &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnpc3" runat="server" Text="Search" />
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

<asp:TextBox autocomplete="off" ID="ProductCode3Search" OnTextChanged="ProductCode3Search_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
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




<asp:TextBox autocomplete="off" runat="server" type="text" MaxLength="17" ID="TxtProductCode3" ValidationGroup="Productcode" OnTextChanged="TxtProductCode3_TextChanged" AutoPostBack="true" TabIndex="165" Style="text-transform: uppercase"></asp:TextBox>
<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProductCode3" ID="RegularExpressionValidator72" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>
<br />
<p>Quantity</p>
<asp:TextBox autocomplete="off" Width="70" runat="server" type="text" MaxLength="16" ValidationGroup="Productcode" onkeypress="return noAlphabets(event)" ID="TxtProQty3" TabIndex="166"></asp:TextBox>


<asp:DropDownList CssClass="drop" ID="DrpP3" runat="server" Width="70" Height="25" TabIndex="167"></asp:DropDownList>
<br />

<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProQty3" ID="RegularExpressionValidator73" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>

</div>
<div class="col-sm-9">

<p>End User Description</p>
<asp:TextBox autocomplete="off" Width="100%" runat="server" style="text-transform :uppercase" type="text"   onchange="countChars2(this);" ID="EndUserDesp3" ValidationGroup="Productcode" TextMode="MultiLine" Text="" TabIndex="168"></asp:TextBox>
<br />
      <p id="end3">0 characters</p>
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="EndUserDesp3" ID="RegularExpressionValidator80" ValidationExpression="^[\s\S]{0,256}$" runat="server" ErrorMessage="Maximum 256 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>


<br />

<asp:GridView CssClass="table table-striped table-bordered table-hover" ID="ProductCode3Grid1" runat="server" ShowFooter="true" AutoGenerateColumns="false">
<PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
<Columns>

<asp:BoundField DataField="RowNumber" HeaderText="Row Number" Visible="false" />

<asp:TemplateField HeaderText="CASC CODE 1">

<ItemTemplate>

<asp:TextBox autocomplete="off" ID="TextBox1" MaxLength="35" TabIndex="169" runat="server"></asp:TextBox>

</ItemTemplate>

</asp:TemplateField>

<asp:TemplateField HeaderText="CASC CODE 2">

<ItemTemplate>

<asp:TextBox autocomplete="off" ID="TextBox2" MaxLength="35" TabIndex="170" runat="server"></asp:TextBox>

</ItemTemplate>

</asp:TemplateField>

<asp:TemplateField HeaderText="CASC CODE 3">

<ItemTemplate>

<asp:TextBox autocomplete="off" ID="TextBox3" MaxLength="35" TabIndex="171" runat="server"></asp:TextBox>

</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="ADD">

<ItemTemplate>
<asp:Button ID="ProductCode3Add" OnClick="ProductCode3Add_Click" runat="server" Text="Add" />
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



</div>
</div>
<div class="row">
<div class="col-sm-3">


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

<asp:TextBox autocomplete="off" ID="ProductCode4Search" OnTextChanged="ProductCode4Search_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
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

<asp:TextBox autocomplete="off" runat="server" type="text" ID="TxtProductCode4" MaxLength="17" ValidationGroup="Productcode" OnTextChanged="TxtProductCode4_TextChanged" AutoPostBack="true" TabIndex="172"></asp:TextBox>
<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProductCode4" ID="RegularExpressionValidator74" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>
<br />
<p>Quantity</p>
<asp:TextBox autocomplete="off" Width="70" runat="server" type="text" ValidationGroup="Productcode" ID="TxtProQty4" MaxLength="16" TabIndex="173"></asp:TextBox>

<asp:DropDownList CssClass="drop" ID="DrpP4" runat="server" Width="70" Height="25" TabIndex="174"></asp:DropDownList>

<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProQty4" onkeypress="return noAlphabets(event)"  ID="RegularExpressionValidator75" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>

</div>
<div class="col-sm-9">

<p>End User Description</p>
<asp:TextBox autocomplete="off" Width="100%" runat="server" type="text" style="text-transform :uppercase" ID="EndUserDesp4"  onchange="countChars3(this);" ValidationGroup="Productcode" TextMode="MultiLine" Text="" TabIndex="175"></asp:TextBox>
<br />
      <p id="end4">0 characters</p>
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="EndUserDesp4" ID="RegularExpressionValidator81" ValidationExpression="^[\s\S]{0,256}$" runat="server" ErrorMessage="Maximum 256 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>


<br />

<asp:GridView CssClass="table table-striped table-bordered table-hover" ID="ProductCode4Grid1" runat="server" ShowFooter="true" AutoGenerateColumns="false">
<PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
<Columns>

<asp:BoundField DataField="RowNumber" HeaderText="Row Number" Visible="false" />

<asp:TemplateField HeaderText="CASC CODE 1">

<ItemTemplate>

<asp:TextBox autocomplete="off" ID="TextBox1" MaxLength="35" TabIndex ="176" runat="server"></asp:TextBox>

</ItemTemplate>

</asp:TemplateField>

<asp:TemplateField HeaderText="CASC CODE 2">

<ItemTemplate>

<asp:TextBox autocomplete="off" ID="TextBox2" MaxLength="35" TabIndex ="177" runat="server"></asp:TextBox>

</ItemTemplate>

</asp:TemplateField>

<asp:TemplateField HeaderText="CASC CODE 3">

<ItemTemplate>

<asp:TextBox autocomplete="off" ID="TextBox3" MaxLength="35" TabIndex ="178" runat="server"></asp:TextBox>

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



</div>
</div>
<div class="row">
<div class="col-sm-3">
<p>Product Code &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnpc5"  runat="server" Text="Search" /></p>


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

<asp:TextBox autocomplete="off" ID="ProductCode5Search" OnTextChanged="ProductCode5Search_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
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



<asp:TextBox autocomplete="off" runat="server" type="text" ID="TxtProductCode5" MaxLength="17" ValidationGroup="Productcode" OnTextChanged="TxtProductCode5_TextChanged" AutoPostBack="true" TabIndex="179"></asp:TextBox>
<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProductCode5" ID="RegularExpressionValidator76" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>
<br />
<p>Quantity</p>
<asp:TextBox autocomplete="off" Width="70" runat="server" type="text" ValidationGroup="Productcode" ID="TxtProQty5" MaxLength="16" TabIndex="180"></asp:TextBox>

<asp:DropDownList CssClass="drop" ID="DrpP5" runat="server" Width="70" Height="25" TabIndex="181"></asp:DropDownList>

<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProQty5" onkeypress="return noAlphabets(event)" ID="RegularExpressionValidator77" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>

</div>
<div class="col-sm-9">

<p>End User Description</p>
<asp:TextBox autocomplete="off" Width="100%" runat="server" style="text-transform :uppercase" type="text"  onchange="countChars4(this);" ID="EndUserDesp5" ValidationGroup="Productcode" TextMode="MultiLine" Text="" TabIndex="182"></asp:TextBox>
<br />
      <p id="end5">0 characters</p>
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="EndUserDesp5" ID="RegularExpressionValidator82" ValidationExpression="^[\s\S]{0,256}$" runat="server" ErrorMessage="Maximum 256 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>


<br />


<asp:GridView CssClass="table table-striped table-bordered table-hover" ID="ProductCode5Grid1" runat="server" ShowFooter="true" AutoGenerateColumns="false">
<PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
<Columns>

<asp:BoundField DataField="RowNumber" HeaderText="Row Number" Visible="false" />

<asp:TemplateField HeaderText="CASC CODE 1">

<ItemTemplate>

<asp:TextBox autocomplete="off" ID="TextBox1" MaxLength="35" TabIndex ="183" runat="server"></asp:TextBox>

</ItemTemplate>

</asp:TemplateField>

<asp:TemplateField HeaderText="CASC CODE 2">

<ItemTemplate>

<asp:TextBox autocomplete="off" ID="TextBox2" MaxLength="35" TabIndex ="184" runat="server"></asp:TextBox>

</ItemTemplate>

</asp:TemplateField>

<asp:TemplateField HeaderText="CASC CODE 3">

<ItemTemplate>

<asp:TextBox autocomplete="off" ID="TextBox3" MaxLength="35" TabIndex ="185" runat="server"></asp:TextBox>

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
<asp:DropDownList CssClass="drop" ID="DrpPreferentialCode" OnSelectedIndexChanged="DrpPreferentialCode_SelectedIndexChanged" AutoPostBack="true" runat="server" Width="250" Height="25"></asp:DropDownList>
</div>
</div>



</div>
<div class="col-sm-6">
</div>
</div>


<br />

<div id="Div3" class="row" style="background-color: black; color: white; height: 20px;" runat="server" visible="false">
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
<div id="Div4" class="row" runat="server" visible="false">
<div class="col-sm-6">
GST (<asp:CheckBox ID="chk234" runat="server" />
Auto-compute duties and taxes)
</div>
<div class="col-sm-2">
<asp:TextBox autocomplete="off" ID="ItemGSTRate" runat="server" Width="120" Text="174"></asp:TextBox>

</div>
<div class="col-sm-2">
<asp:TextBox autocomplete="off" ID="ItemGSTUOM" runat="server" Width="120" Text="PER" ></asp:TextBox>

</div>
<div class="col-sm-2">
<asp:TextBox autocomplete="off" ID="TxtItemSumGST" runat="server" Width="120" Text="0.00" ></asp:TextBox>
</div>
</div>


<div id="Div5" class="row" runat="server" visible="false">
<div class="col-sm-6">
Excise Duty
</div>
<div class="col-sm-2">
<asp:TextBox autocomplete="off" ID="TxtExciseDutyRate" runat="server" Width="120" Text="0.00" ></asp:TextBox>
</div>
<div class="col-sm-2">
<asp:TextBox autocomplete="off" ID="TxtExciseDutyUOM" runat="server" Width="120" Text="0.00" ></asp:TextBox>
</div>
<div class="col-sm-2">
<asp:TextBox autocomplete="off" ID="TxtSumExciseDuty" runat="server" Width="120" Text="0.00" ></asp:TextBox>
</div>
</div>

<div id="Div7" class="row" runat="server" visible="false">
<div class="col-sm-6">
<asp:Label ID="lblCustomsDuty" Text="Customs Duty" Width="120" runat="server"></asp:Label>
</div>
<div class="col-sm-2">
<asp:TextBox autocomplete="off" ID="TxtCustomsDutyRate" runat="server" Width="120" Text="0.00" ></asp:TextBox>
</div>
<div class="col-sm-2">
<asp:TextBox autocomplete="off" ID="TxtCustomsDutyUOM" runat="server" Width="120" Text="0.00" ></asp:TextBox>
</div>
<div class="col-sm-2">
<asp:TextBox autocomplete="off" ID="TxtSumCustomsDuty" runat="server" Width="120" Text="0.00" ></asp:TextBox>
</div>
</div>

<div id="Div8" class="row" runat="server" visible="false">
<div class="col-sm-6">
Other Tax
</div>
<div class="col-sm-2">
<asp:TextBox autocomplete="off" ID="TxtOtherTaxRate" runat="server" Width="120" Text="0.00" ></asp:TextBox>
</div>
<div class="col-sm-2">
<asp:DropDownList CssClass="drop" ID="DrpOtherUOM" Width="120" runat="server" ></asp:DropDownList>
</div>
<div class="col-sm-2">
<asp:TextBox autocomplete="off" ID="TxtSumOtherTaxRate" runat="server" Width="120" Text="0.00" ></asp:TextBox>
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
<asp:TextBox autocomplete="off" runat="server" type="text" ValidationGroup="Item" ID="TxtCurrentLot" TabIndex="187" class="w3-input w3-hover-green"></asp:TextBox>
<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtCurrentLot" ID="RegularExpressionValidator83" ValidationExpression="^[\s\S]{0,30}$" runat="server" ErrorMessage="Maximum 30 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
</div>
<div class="col-sm-4">
<p>Marking </p>
<asp:DropDownList CssClass="drop" Height="30" runat="server" ID="DrpMaking" Width="250" TabIndex="188"></asp:DropDownList>
</div>
<div class="col-sm-4">
<p>Previous Lot</p>
<asp:TextBox autocomplete="off" runat="server" type="text" ID="TxtPreviousLot" ValidationGroup="Item" TabIndex="189" class="w3-input w3-hover-green"></asp:TextBox>
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
<p>Shipping Marks 1</p>
<asp:TextBox autocomplete="off" runat="server" type="text" ID="txtShippingMarks1" Style="text-transform :uppercase" TextMode="MultiLine" TabIndex="202" ValidationGroup="Shipping"></asp:TextBox>
<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtShippingMarks1" ID="RegularExpressionValidator85" ValidationExpression="^[\s\S]{0,170}$" runat="server" ErrorMessage="Maximum 170 characters allowed." ValidationGroup="Shipping"></asp:RegularExpressionValidator>
</div>
<div class="col-sm-3">
<p>Shipping Marks 2</p>
<asp:TextBox autocomplete="off" runat="server" type="text" ID="txtShippingMarks2" Style="text-transform :uppercase" TextMode="MultiLine" TabIndex="203" ValidationGroup="Shipping"></asp:TextBox>
<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtShippingMarks2" ID="RegularExpressionValidator101" ValidationExpression="^[\s\S]{0,170}$" runat="server" ErrorMessage="Maximum 170 characters allowed." ValidationGroup="Shipping"></asp:RegularExpressionValidator>
</div>
<div class="col-sm-3">
<p>Shipping Marks 3</p>
<asp:TextBox autocomplete="off" runat="server" type="text" ID="txtShippingMarks3" Style="text-transform :uppercase" TextMode="MultiLine" TabIndex="204" ValidationGroup="Shipping"></asp:TextBox>
<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtShippingMarks3" ID="RegularExpressionValidator86" ValidationExpression="^[\s\S]{0,136}$" runat="server" ErrorMessage="Maximum 136 characters allowed." ValidationGroup="Shipping"></asp:RegularExpressionValidator>
</div>
<div class="col-sm-3">
<p>Shipping Marks 4</p>
<asp:TextBox autocomplete="off" runat="server" type="text" ID="txtShippingMarks4" Style="text-transform :uppercase" TextMode="MultiLine" TabIndex="205" ValidationGroup="Shipping"></asp:TextBox>
<br />
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtShippingMarks4" ID="RegularExpressionValidator87" ValidationExpression="^[\s\S]{0,36}$" runat="server" ErrorMessage="Maximum 36 characters allowed." ValidationGroup="Shipping"></asp:RegularExpressionValidator>
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
<div class="col-sm-4">
<asp:Button ID="BtnItemAdd" CssClass="btn btn-block btn-success" ValidationGroup="Item" runat="server" Visible ="false" Text="Add Item" OnClick="BtnItemAdd_Click1" />

</div>

<div class="col-sm-8">
</div>
</div>

</div>
</div>
<center>
   <%-- <div class="row">
<asp:UpdatePanel ID ="UpdatePanel4" runat ="server" UpdateMode ="Conditional" >
<ContentTemplate>
<div class="col-sm-7">
<p>Uplaod Document</p>
<asp:FileUpload Height="35" id="FileUpload4" class="btn" runat="server" AllowMultiple="true" />
<asp:Label runat="server" id="Label6" />
</div>
<div class="col-sm-5">
<p>Uplaod</p>
<asp:Button ID="BtnExcelUp" runat="server" OnClick="BtnExcelUp_Click" Text="Save" class="btn btn-success" />
<asp:Label runat="server" id="Error1" />
</div>
</ContentTemplate>
<Triggers>
<asp:PostBackTrigger ControlID="BtnExcelUp" />
</Triggers>
</asp:UpdatePanel>
</div>--%>
     <div class="row">
                                                                                     <center>
                                                                                     <div class="row">
                                                                                         <div class="col-sm-12">
                                                                                          <div class="row Borderdiv" style="width: 90%">
                                                                                        Upload Item Template
                                                                                    </div><br />
                                                                                             </div>
                                                                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                                                                            <ContentTemplate>
                                                                                               
                                                                                                <div class="col-sm-4"> <a href="ExcelTemplate/InpaymentItemUpload.xlsx"  class="btn1">Download Item Excel Template Here</a>
                                                                                                
                                                                                                    </div>
                                                                                                <div class="col-sm-4">
                                                                                                    
                                                                                                    <asp:FileUpload Height="35" ID="FileUpload4" class="btn" runat="server" AllowMultiple="true" />
                                                                                                    <asp:Label runat="server" ID="Label6" />
                                                                                                </div>

                                                                                               <div class="col-sm-4">
                                                                                                  
                                                                                                    <asp:Button ID="BtnExcelUp" runat="server" OnClick="BtnExcelUp_Click" Text="Upload Excel" class="btn1 btn-primary"/>
                                                                                                    <asp:Label runat="server" ID="Label7" />

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
    <br /><br />


                                                        <div class="flex justify-between gap-4 md:flex-nowrap flex-wrap mt-6 mb-6">
    <asp:Button ID="btnprevitem" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full" runat="server" class="btn btn-info btn-lg" OnClick="btnprevitem_Click" Text="Previous" TabIndex="174" />

    <div class="flex gap-4 flex-wrap md:flex-nowrap md:max-w-[260px] w-full">
        <asp:Button ID="btnresetitem" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full" runat="server" class="btn btn-info btn-lg" OnClick="btnresetitem_Click" Text="Reset" TabIndex="176" />

        <asp:Button ID="btnsaveitem" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] bg-opacity-10 border hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-[#0560FD] text-center rounded-md text-sm sa700" runat="server" class="btn btn-info btn-lg" ValidationGroup="Item" OnClick="btnsaveitem_Click" Text="+ Add Item" TabIndex="175" />

    </div>
    <asp:Button ID="btnnextitem" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" runat="server" class="btn btn-info btn-lg" OnClick="btnnextitem_Click" Text="Next" TabIndex="177" />

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
<asp:TextBox autocomplete="off" ID="AddItemSearch" OnTextChanged="AddItemSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
<br />
<asp:GridView ID="AddItemGrid" Font-Size="10" OnRowDeleting="AddItemGrid_RowDeleting" PageSize="50" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="AddItemGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
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

</ContentTemplate>
</asp:UpdatePanel>
</ContentTemplate>
</cc1:TabPanel>

<cc1:TabPanel ID="TabPanel1" runat="server" CssClass="nn" HeaderText="CPC">
<ContentTemplate>
<asp:UpdatePanel ID="transhipcpc" UpdateMode="Conditional" runat="server">
<ContentTemplate>

<div class="row">
<div class="col-sm-12">
<div class="row">
<div class="col-sm-2">
<asp:CheckBox ID="chkaeo" OnCheckedChanged="chkaeo_CheckedChanged" AutoPostBack="true" runat="server" Text="AEO" Checked="false" TabIndex="210" />
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

<asp:TextBox autocomplete="off" ID="TextBox1" runat="server" TabIndex="211"></asp:TextBox>

</ItemTemplate>

</asp:TemplateField>

<asp:TemplateField HeaderText="Processing Code2">

<ItemTemplate>

<asp:TextBox autocomplete="off" ID="TextBox2" runat="server" TabIndex="212"></asp:TextBox>

</ItemTemplate>

</asp:TemplateField>

<asp:TemplateField HeaderText="Processing Code3">

<ItemTemplate>

<asp:TextBox autocomplete="off" ID="TextBox3" runat="server" TabIndex="213"></asp:TextBox>

</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Delete">
<ItemTemplate>
<asp:LinkButton OnClick="imgDelete_Click1" data-target='<%#"#"+DataBinder.Eval(Container.DataItem,"RowNumber")%>' Width="11" Height="11" ID="imgDelete" runat="server"><i class='fa fa-trash' style="color:red"></i></asp:LinkButton>

<%--<div class="modal fade" id='<%#Eval("RowNumber")%>' role="dialog">
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
<asp:CheckBox ID="chkcwc" OnCheckedChanged="chkcwc_CheckedChanged" AutoPostBack="true" runat="server" Text="STS" Checked="false" TabIndex="214" />
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

<asp:TextBox autocomplete="off" ID="TextBox1" runat="server" TabIndex="215"></asp:TextBox>

</ItemTemplate>

</asp:TemplateField>

<asp:TemplateField HeaderText="Processing Code2">

<ItemTemplate>

<asp:TextBox autocomplete="off" ID="TextBox2" runat="server" TabIndex="216"></asp:TextBox>

</ItemTemplate>

</asp:TemplateField>

<asp:TemplateField HeaderText="Processing Code3">

<ItemTemplate>

<asp:TextBox autocomplete="off" ID="TextBox3" runat="server" TabIndex="217"></asp:TextBox>

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
<asp:CheckBox ID="ChkSea1" OnCheckedChanged="ChkSea_CheckedChanged" AutoPostBack="true" runat="server" Text="SEA STORE" Checked="false" TabIndex="218" />
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

<asp:TextBox autocomplete="off" ID="TextBox1" runat="server" TabIndex="219"></asp:TextBox>

</ItemTemplate>

</asp:TemplateField>

<asp:TemplateField HeaderText="Processing Code2">

<ItemTemplate>

<asp:TextBox autocomplete="off" ID="TextBox2" runat="server" TabIndex="220"></asp:TextBox>

</ItemTemplate>

</asp:TemplateField>

<asp:TemplateField HeaderText="Processing Code3">

<ItemTemplate>

<asp:TextBox autocomplete="off" ID="TextBox3" runat="server" TabIndex="221"></asp:TextBox>

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
<asp:CheckBox ID="chkcnb" runat="server" Text="CNB" Checked="false" TabIndex="222" />
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


<cc1:TabPanel ID="Summary" runat="server" CssClass="nn" HeaderText="Summary">
<ContentTemplate>
<asp:UpdatePanel ID="transhipsummery" UpdateMode="Conditional" runat="server">
<ContentTemplate>
<div class="col-sm-12">
<asp:ValidationSummary ID="ValidationSummary16" runat="server" ShowMessageBox="True"
ShowSummary="False" ValidationGroup="Summery" />
<div class="row">
<div class="col-sm-12">
<div class="row">
<div class="col-sm-4">
<div class="form-group row">
<label for="staticEmail" class="col-sm-6 col-form-label">
Tot CIF/FOB Val
</label>
<div class="col-sm-6">
<asp:TextBox autocomplete="off" runat="server" Enabled="false" Text ="0.00" Width="100" type="text" ID="txtfobval" ></asp:TextBox>
</div>
</div>
</div>
<div class="col-sm-4">
<div class="form-group row">
<label for="staticEmail" class="col-sm-6 col-form-label">
No of Items
</label>
<div class="col-sm-6">
<asp:TextBox autocomplete="off" runat="server" Text="0.00" Enabled="false" Width="100" type="text" ID="txtnoofitm" ></asp:TextBox>
</div>
</div>
</div>
<div class="col-sm-4">
<div class="form-group row">
<label for="staticEmail" class="col-sm-6 col-form-label">
Sum of Item Amt
</label>
<div class="col-sm-6">
<asp:TextBox autocomplete="off" runat="server" Text="0.00" Enabled="false" Width="100" type="text" ID="txtitmAmt" ></asp:TextBox>
</div>
</div>
</div>

</div>
<div class="row">
<div class="col-sm-12">
<div class="form-group row">
<label id="Label5" for="staticEmail" runat ="server" visible ="false" class="col-sm-6 col-form-label">
Tot Inv CIF Val
</label>
<div class="col-sm-6">
<asp:TextBox autocomplete="off" runat="server" Visible="false" Text="0.00" Enabled="false" Width="100" type="text" ID="txtcifVal" ></asp:TextBox>
</div>
</div>
</div>
</div>
<div class="row">
<div class="col-sm-2">
<asp:CheckBox ID="chkAuto" Enabled="false" Width="200" runat="server" Text="Auto-Compute" />
</div>


</div>

<div class="row">
<div class="col-sm-12">
<div class="form-group row">
<label for="staticEmail" class="col-sm-6 col-form-label">
</label>
<div class="col-sm-6">




<p id="cusremarks" runat="server" visible="false">Customer Remarks(will Not be Submitted to Singapore Customs)</p>
<asp:TextBox autocomplete="off" ID="txtcusRemrk" Visible="false" runat="server" TextMode="MultiLine" Height="70" Width="100%"></asp:TextBox>



</div>

</div>
</div>
</div>
<div class="row">
<div class="col-sm-12">
Trader's Remarks(will be Submitted to Singapore Customs)
<asp:Button ID="btninvnum" runat="server" TabIndex ="227" OnClick="btninvnum_Click" Text="Append Invoice Number" /><asp:Button ID="Button5" TabIndex="228" OnClick="Button3_Click" runat="server" Text="Append Ex Rate" />Cross Reference<asp:TextBox autocomplete="off" TabIndex ="229" Style="width:250px;" runat="server" type="text" ID="TxtGrossReference" Visible="true"></asp:TextBox>

<asp:TextBox autocomplete="off" ID="txttrdremrk"  onchange="countCharstrade(this)" ValidationGroup="Summery" runat="server" TextMode="MultiLine" MaxLength="1024" TabIndex="230" Height="70" Width="100%" Style="text-transform: uppercase"></asp:TextBox>
<br />
    <p id="trade" runat="server"></p>
<asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txttrdremrk" ID="RegularExpressionValidator50" ValidationExpression="^[\s\S]{0,1024}$" runat="server" ErrorMessage="Maximum 1024 characters allowed." ValidationGroup="Summery"></asp:RegularExpressionValidator>
</div>
</div>
<div class="row">
<div class="col-sm-12">


<div class="form-group row">

<div class="col-sm-12">

<p>INTERNAL REFERENCE</p>
<asp:TextBox autocomplete="off" ID="txtintremrk" runat="server" Height="70" TabIndex="231" Width="100%" Style="text-transform: uppercase"></asp:TextBox>
</div>
</div>
</div>
</div>

<div class="row">
<div class="col-sm-3">

<div id ="in" runat ="server" visible ="false" >
<div class="form-group row">
<label id="Label2" for="staticEmail" runat ="server" visible ="false" class="col-sm-6 col-form-label">
No of Invoices
</label>
<div class="col-sm-6">
<asp:TextBox autocomplete="off" runat="server" Visible="false" Text="0.00" Enabled="false" Width="100" type="text" ID="txtnoofinv" ></asp:TextBox>
</div>
</div>
</div>

</div>
<div class="col-sm-3">
<div class="form-group row">
<label for="staticEmail" runat ="server" visible ="false" class="col-sm-6 col-form-label">
Ttl GST Amt
</label>
<div class="col-sm-6">
<asp:TextBox autocomplete="off" runat="server" Enabled="false" Visible ="false" Text="0.00" Width="100" type="text" ID="txttotgstAmt" ></asp:TextBox>
</div>
</div>
</div>
<div class="col-sm-3">
<div class="form-group row">
<label for="staticEmail" runat ="server" visible ="false" class="col-sm-6 col-form-label">
Ttl Exc Duty Amt
</label>
<div class="col-sm-6">
<asp:TextBox autocomplete="off" runat="server" Enabled="false" Width="100" Visible ="false" Text="0.00" type="text" ID="txttotexAmt" ></asp:TextBox>
</div>
</div>
</div>
<div class="col-sm-3">
<div class="form-group row">
<label for="staticEmail" runat ="server" visible ="false" class="col-sm-6 col-form-label">
Ttl Cus Duty Amt
</label>
<div class="col-sm-6">
<asp:TextBox autocomplete="off" runat="server" Enabled="false" Visible ="false" Width="100" type="text" ID="txtcusdutyAmt" ></asp:TextBox>
</div>
</div>
</div>
</div>
<div class="row">
<div class="col-sm-3">
<div class="form-group row">
<label for="staticEmail" runat ="server" visible ="false" class="col-sm-6 col-form-label">
Ttl Other Tax Amt
</label>
<div class="col-sm-6">
<asp:TextBox autocomplete="off" runat="server" Enabled="false" Visible ="false" Text="0.00" Width="100" type="text" ID="txtothtaxAmt" ></asp:TextBox>
</div>
</div>
</div>
<div class="col-sm-3">
<div class="form-group row">
<label for="staticEmail" runat ="server" visible ="false" class="col-sm-6 col-form-label">
Ttl Amt Payable
</label>
<div class="col-sm-6">
<asp:TextBox autocomplete="off" runat="server" Enabled="false" Width="100" Text="0.00" Visible ="false" type="text" ID="txtAmtPayble"></asp:TextBox>
</div>
</div>
</div>
<div class="col-sm-3">
<div class="form-group row">
<label for="staticEmail" runat ="server" visible ="false" class="col-sm-6 col-form-label">
Sum Of InvAmt
</label>
<div class="col-sm-6">
<div id="div9" runat="server" visible="false"></div>
<asp:TextBox autocomplete="off" runat="server" Visible ="false" Text="0.00" type="text" ID="txtinvAmt" TabIndex="1"></asp:TextBox>
<br />
</div>
</div>
</div>
<div class="col-sm-3">
<div class="form-group row">
<label id="lblintremknot" runat="server" visible="false" for="staticEmail" class="col-sm-6 col-form-label">
Internal Remarks

</label>
<div class="col-sm-6">
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
<br />
<div class="col-sm-12">
<div class="form-group row">
<br />
<label for="staticEmail" class="col-sm-3 col-form-label">

Importer


</label>
<div class="col-sm-9">
<asp:Label ID="lblimporterparty" runat="server" Width="80%" Text="" Font-Size="Medium" Font-Bold="true"></asp:Label>
<%--<asp:TextBox autocomplete="off" runat="server" Enabled="false" Width="100" type="text" ID="TextBox25" TabIndex="1"></asp:TextBox>--%>
</div>
</div>
</div>
<div class="col-sm-12">
<div class="form-group row">

<label for="staticEmail" class="col-sm-3 col-form-label">

Handling Agent


</label>
<div class="col-sm-9">
<asp:Label ID="LblHandAgent" runat="server" Width="80%" Text="" Font-Size="Medium" Font-Bold="true"></asp:Label>
<%--<asp:TextBox autocomplete="off" runat="server" Enabled="false" Width="100" type="text" ID="TextBox25" TabIndex="1"></asp:TextBox>--%>
</div>
</div>
</div>

<div class="col-sm-6">
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
InOBL


</label>
<div class="col-sm-9">
<asp:Label ID="lbloblval" runat="server" Width="80%" Text="" Font-Size="Medium" Font-Bold="true"></asp:Label>
<%--<asp:TextBox autocomplete="off" runat="server" Enabled="false" Width="100" type="text" ID="TextBox25" TabIndex="1"></asp:TextBox>--%>
</div>
</div>
</div>
<div class="col-sm-6">
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
InHBL
</label>
<div class="col-sm-9">
<asp:Label ID="lblhblValue" runat="server" Width="80%" Font-Size="Medium" Font-Bold="true"></asp:Label>
<%--<asp:TextBox autocomplete="off" runat="server" Enabled="false" Width="80%" type="text" ID="TextBox26" TabIndex="1"></asp:TextBox>--%>
</div>
</div>
</div>
<div class="col-sm-6">
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Out OBL


</label>
<div class="col-sm-9">
<asp:Label ID="lbloutobl" runat="server" Width="80%" Text="" Font-Size="Medium" Font-Bold="true"></asp:Label>
<%--<asp:TextBox autocomplete="off" runat="server" Enabled="false" Width="100" type="text" ID="TextBox25" TabIndex="1"></asp:TextBox>--%>
</div>
</div>
</div>

<div class="col-sm-6">
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Out HBL


</label>
<div class="col-sm-9">
<asp:Label ID="lblouthbl" runat="server" Width="80%" Text="" Font-Size="Medium" Font-Bold="true"></asp:Label>
<%--<asp:TextBox autocomplete="off" runat="server" Enabled="false" Width="100" type="text" ID="TextBox25" TabIndex="1"></asp:TextBox>--%>
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
<%--<asp:TextBox autocomplete="off" runat="server" Enabled="false" Width="100" type="text" ID="TextBox30" TabIndex="1"></asp:TextBox>--%>
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
<%--<asp:TextBox autocomplete="off" runat="server" Enabled="false" Width="100" type="text" ID="TextBox27" TabIndex="1"></asp:TextBox>--%>
</div>
</div>
</div>
<div class="col-sm-6">
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
<%-- Invoice Amount--%>
Item AMOUNT

</label>
<div class="col-sm-9">
<div id="div1" runat="server"></div>
<asp:Label ID="lblinvoiceAmt" Visible="false" runat="server" Width="80%" Font-Size="Medium" Font-Bold="true"></asp:Label>
<%--<asp:TextBox autocomplete="off" runat="server" Enabled="false" Width="100" type="text" ID="TextBox28" TabIndex="1"></asp:TextBox>--%>
</div>
</div>
</div>
<div class="col-sm-6">
<div class="form-group row">
<label for="staticEmail" class="col-sm-3 col-form-label">
Total Item GST

</label>
<div class="col-sm-9">
<asp:Label ID="lblTotItemGst" runat="server" Width="80%" Font-Size="Medium" Font-Bold="true"></asp:Label>
<%--<asp:TextBox autocomplete="off" runat="server" Enabled="false" Width="100" type="text" ID="TextBox31" TabIndex="1"></asp:TextBox>--%>
</div>
</div>
</div>
<div class="col-sm-12" id="DeclInd" runat="server" visible="false">
<div class="alert alert-danger" >
<asp:CheckBox ID="chkalrt" runat="server" Checked="false" TabIndex="239" />
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


</ContentTemplate>
</asp:UpdatePanel>
</ContentTemplate>
</cc1:TabPanel>

<cc1:TabPanel ID="Amend" runat="server" CssClass="nn" Visible="false" HeaderText="Amend">
<ContentTemplate>
<asp:UpdatePanel ID="transhipamend" UpdateMode="Conditional" runat="server">
<ContentTemplate>
<div class="row">
<div class="col-sm-12">
<div class="row Borderdiv" style="width: 100%">Update Information</div>
<div class="row">
<div class="col-sm-6">
<p>Amendment Count</p>
<asp:TextBox autocomplete="off" runat="server" type="text" ID="txtamoundcount" Text="1" Enabled="false" TabIndex="236"></asp:TextBox>
<br />
<p>Update Indicator</p>
<asp:TextBox autocomplete="off" runat="server" type="text" ID="txtupdateindicator" TabIndex="237"></asp:TextBox>
<br />
</div>
<div class="col-sm-6">
<p>Permit Number</p>
<asp:TextBox autocomplete="off" runat="server" type="text" ID="txtamendpermit" TabIndex="238"></asp:TextBox>
<br />
<p>Replacement Permit Number</p>
<asp:TextBox autocomplete="off" runat="server" type="text" ID="txtreplacepermit" TabIndex="239"></asp:TextBox>
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
<asp:TextBox autocomplete="off" runat="server" TextMode="MultiLine" Width="100%" type="text" ID="txtdescreason" TabIndex="240"></asp:TextBox>
<br />
<asp:CheckBox ID="ChkPermitvalEx" runat="server" Text="Permit Validity Extension" />
<br />
<p>Extend Import Period (Reason for Extension of validity for Temporary / Exhibit Cargoes)</p>
<asp:TextBox autocomplete="off" runat="server" TextMode="MultiLine" Width="100%" type="text" ID="txtvalidity" TabIndex="241"></asp:TextBox>
<br />
<br />
<div class="row Borderdiv" style="width: 100%">Declaration Indicator</div>
<div class="alert alert-danger" id="AmendInd" runat="server" visible="false">
<asp:CheckBox ID="chkdec" runat="server" Checked="false" TabIndex="242" />
<strong></strong>I/We declare that all particulars in this application are true and correct
</div>
</div>
</div>

<center>
<div class="btn-group btn-group-lg" id="Amendbtn" runat="server" visible="false">
<asp:Button ID="btnsaveamend" Visible="false" CssClass="nn" runat="server" class="btn btn-info btn-lg" OnClick="btnsaveamend_Click" Text="Save" TabIndex="243" />
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
<div class="row Borderdiv" style="width: 100%">Update Information</div>
<div class="row">
<div class="col-sm-6">
<p>Update Indicator</p>
<asp:TextBox autocomplete="off" runat="server" type="text" ID="txtupdateInd" TabIndex="244"></asp:TextBox>
<br />


</div>
<div class="col-sm-6">
<p>Permit Number</p>
<asp:TextBox autocomplete="off" runat="server" type="text" ID="txtcanPermit" TabIndex="245"></asp:TextBox>
<br />
<p>Replacement Permit Number</p>
<asp:TextBox autocomplete="off" runat="server" type="text" ID="txtcanrepPermit" TabIndex="246"></asp:TextBox>
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
<asp:DropDownList CssClass="drop" ID="DrpReasonCancel" Height="26" runat="server" TabIndex="247"></asp:DropDownList>
</div>
<div class="col-sm-6">
<p>Description For Reason</p>
<asp:TextBox autocomplete="off" runat="server" TextMode="MultiLine" Width="100%" type="text" ID="txtdesReason" TabIndex="248"></asp:TextBox>
<br />
</div>
</div>
<br />
<div class="row">
<div class="col-sm-12" id="Div10" runat="server">

<div class="row">


<div class="col-sm-12">
<div class="row Borderdiv" style="width: 100%">
Referance Document
</div>

<div class="row">
<div class="col-sm-5">
<p>Document Type</p>
<asp:DropDownList CssClass="drop" ID="DrpDocumenttype" BackColor="ActiveCaption" Width="250" Height="32" AppendDataBoundItems="true" TabIndex="249" runat="server">
</asp:DropDownList><br />
<%--<asp:RequiredFieldValidator BackColor="Red" ID="RequiredFieldValidator27" runat="server" ControlToValidate="DrpDocumenttype" InitialValue="0" ErrorMessage="Header --> Doc Type" ValidationGroup="Validationbtn"></asp:RequiredFieldValidator>--%>
</div>
<div class="col-sm-5">
<p>Uplaod Document</p>
<asp:FileUpload ID="FileUpload2" BackColor="ActiveCaption" runat="server" class="btn" AllowMultiple="true" />
<%--<asp:RequiredFieldValidator BackColor="Red" ID="RequiredFieldValidator67" runat="server" ControlToValidate="FileUpload1" ErrorMessage="Header -->Upload Doc" ValidationGroup="Validationbtn"></asp:RequiredFieldValidator>--%>
</div>
<div class="col-sm-2">
<p>Uplaod</p>
<asp:Button runat="server" ID="BtnCancelUp" ValidationGroup="Validationbtn" class="btn btn-success" Text="Upload" OnClick="BtnCancelUp_Click" />

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
<asp:TextBox autocomplete="off" ID="TextBox15" Width="265" runat="server" TabIndex="250" type="text"></asp:TextBox>

<br />
</div>
<div class="col-sm-4">
<p>RECIPIENTS 2</p>
<asp:TextBox autocomplete="off" ID="TextBox16" Width="265" runat="server" TabIndex="251" type="text"></asp:TextBox>

<br />
</div>
<div class="col-sm-4">
<p>RECIPIENTS 3</p>
<asp:TextBox autocomplete="off" ID="TextBox17" Width="265" runat="server" TabIndex="252" type="text"></asp:TextBox>

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
<div class="alert alert-danger" id="CancelInd" runat="server" visible="false">
<asp:CheckBox ID="CheckBox4" runat="server" Checked="false" TabIndex="268" />
<strong></strong>I/We declare that all particulars in this application are true and correct
</div>

</div>
</div>

<center>
<div class="btn-group btn-group-lg" id="CancelBtn" runat="server" visible="false">

<asp:Button ID="btnsavecancel" Visible="false" CssClass="nn" runat="server" class="btn btn-info btn-lg" OnClick="btnsavecancel_Click" Text="Save" TabIndex="277" />


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








</div>

</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
