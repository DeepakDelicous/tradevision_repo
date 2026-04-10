<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ManageUser.aspx.cs" Inherits="RET.ManageUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <style>
        .modern-tabs {
            --active-color: #4f46e5;
            --hover-color: #6366f1;
            --background: #ffffff;
            --text-color: #374151;
            --border-radius: 12px;
            --transition: all 0.3s cubic-bezier(0.4, 0, 0.2, 1);
        }

        .tab-nav {
            position: relative;
            max-width: 600px;
            margin: 0 auto;
            padding: 1.5rem;
            background: var(--background);
            border-radius: var(--border-radius);
        }

        .tab-list {
            display: flex;
            justify-content: center;
            gap: 2rem;
            padding: 0;
            margin: 0;
            list-style: none;
        }

        .tab-item {
            position: relative;
            z-index: 1;
        }

        .tab-link {
            display: flex;
            flex-direction: column;
            align-items: center;
            text-decoration: none;
            color: var(--text-color);
            transition: var(--transition);
            padding: 1rem;
            border-radius: 0.75rem;
        }

        .tab-icon {
            width: 48px;
            height: 48px;
            display: flex;
            align-items: center;
            justify-content: center;
            background: #f8fafc;
            border-radius: 50%;
            margin-bottom: 0.75rem;
            transition: var(--transition);
            box-shadow: 0 1px 3px rgba(0, 0, 0, 0.1);
        }

        .tab-icon svg {
            width: 24px;
            height: 24px;
            fill: currentColor;
        }

        .tab-label {
            font-family: 'Inter', sans-serif;
            font-weight: 500;
            font-size: 0.875rem;
            opacity: 0.8;
            transition: var(--transition);
        }

        /* Active State */
        .tab-item.active .tab-icon {
            background: var(--active-color);
            color: white;
            transform: translateY(-5px);
            box-shadow: 0 10px 15px -3px rgba(79, 70, 229, 0.3);
        }

        .tab-item.active .tab-label {
            color: var(--active-color);
            opacity: 1;
            transform: translateY(2px);
        }

        /* Hover Effects */
        .tab-item:not(.active):hover .tab-icon {
            background: var(--hover-color);
            color: white;
            transform: translateY(-3px);
        }

        .tab-item:not(.active):hover .tab-label {
            color: var(--hover-color);
        }

        /* Progress Line */
        .tab-progress {
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            background: #e5e7eb;
            border-radius: 2px;
            z-index: 0;
        }

        .tab-progress::after {
            content: '';
            position: absolute;
            left: 0;
            top: 0;
            height: 100%;
            width: 50%;
            background: linear-gradient(90deg, var(--active-color), #60a5fa);
            border-radius: 2px;
            transition: var(--transition);
        }

        /* Animation */
        @media (prefers-reduced-motion: no-preference) {
            .tab-icon {
                transition: var(--transition), transform 0.2s ease-out;
            }
    
            .tab-item.active .tab-icon {
                animation: bounce 0.6s ease-out;
            }
        }

        @keyframes bounce {
            0%, 100% { transform: translateY(-5px); }
            50% { transform: translateY(-8px); }
        }
        .add_label_style label{
           font-weight: normal !important;
           padding-left: 10px !important;
        }
    </style>
    
    <script >
         function myFunction() {
             $("#ManageUser").css('color', 'White');
             debugger;
             $("#ManageUser").css('background-color', 'red');
         }
    </script>

     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>


    <div class="flex items-start flex-no-wrap">
         <div class="px-6 py-6 lg:max-w-[1150px] w-full mx-auto">
             <div class="flex gap-y-3 items-center justify-between flex-wrap">
                <div class="">
                  <h1 class="text-2xl sa700 leading-normal text-gray-800">
                    Manage User
                  </h1>
                </div>
                <div class="flex items-center gap-3 flex-wrap">
                  <a href="ManageUserList.aspx"
                    class="duration-300 group ease-in-out gap-3 md:w-[164px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700"
                    >
                    View All Records
                  </a>
                </div>
              </div>
             <div class="w-full bg-white my-shadow rounded-2xl px-6 py-5 mt-4">

                 <div class="container-fluid">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="row">
                                <div class="board">
                                    <!-- <h2>Welcome to IGHALO!<sup>™</sup></h2>-->
                                    <div class="board-inner ">
                                        
                                        <div class="modern-tabs">
                                            <nav class="tab-nav">
                                                <div class="tab-progress"></div>
                                                <ul class="tab-list" id="myTab" >
                                                    <li class="tab-item active">
                                                        <a href="#Header" class="tab-link" data-toggle="tab" title="Header" >
                                                            <span class="tab-icon">
                                                                <svg viewBox="0 0 24 24"><path d="M12 2L2 7l10 5 10-5-10-5zM2 17l10 5 10-5M2 12l10 5 10-5"/></svg>
                                                            </span>
                                                            <span class="tab-label">Header</span>
                                                        </a>
                                                    </li>
                                                    <li class="tab-item">
                                                        <a href="#Party" class="tab-link" data-toggle="tab" title="Party" >
                                                            <span class="tab-icon">
                                                                <svg viewBox="0 0 24 24"><path d="M12 4a4 4 0 014 4 4 4 0 01-4 4 4 4 0 01-4-4 4 4 0 014-4m0 10c4.42 0 8 1.79 8 4v2H4v-2c0-2.21 3.58-4 8-4z"/></svg>
                                                            </span>
                                                            <span class="tab-label">Party</span>
                                                        </a>
                                                    </li>
                                                </ul>
                                            </nav>
                                        </div>

                                        <div class="tab-content">
                                            <div role="tabpanel" class="tab-pane fade in active" id="Header">

                                                <h3 class="text-2xl sa700 leading-normal text-gray-800" style="font-size: 20px;" >ADMIN DETAILS</h3>

                                                <div class="mt-4 flex items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                    <div class="w-full">
                                                         <label class="text-gray-500 text-sm font-medium">Account Id</label>
                                                         <div class="relative mt-1">
                                                             <asp:DropDownList ID="DrpAccountId" CssClass="drop w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server" TabIndex="1"></asp:DropDownList>
                                                         </div>
                                                     </div>

                                                     <div class="w-full">
                                                         <label class="text-gray-500 text-sm font-medium">Password</label>
                                                         <div class="relative mt-1">
                                                             <asp:TextBox ID="txtpassword" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="4" runat="server" ></asp:TextBox>
                                                         </div>
                                                     </div>

                                                    <div class="w-full">
                                                        <label class="text-gray-500 text-sm font-medium">Telephone</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox ID="txttel" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="7" runat="server" ></asp:TextBox>
                                                        </div>
                                                    </div>

                                                </div>

                                                <div class="mt-4 flex items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                    <div class="w-full">
                                                        <label class="text-gray-500 text-sm font-medium">Email</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox ID="txtemail" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="7" runat="server" ></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="w-full">
                                                        <label class="text-gray-500 text-sm font-medium">User Id</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox ID="txtuserid" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="7" runat="server" ></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="w-full">
                                                        <label class="text-gray-500 text-sm font-medium">Confirm Password</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox ID="txtconPassword" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="5" runat="server" ></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="mt-4 flex items-end gap-4 lg:flex-nowrap flex-wrap mb-2">

                                                    <div class="w-full">
                                                        <label class="text-gray-500 text-sm font-medium">Fax</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox ID="txtfax" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="8" runat="server" ></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="w-full">
                                                        <label class="text-gray-500 text-sm font-medium">Status</label>
                                                        <div class="relative mt-1">
                                                            
                                                            <asp:DropDownList ID="DrpStatus" CssClass="drop w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="13"                                 runat="server">
                                                                <asp:ListItem Text="--Select--" Value="--Select--"></asp:ListItem>
                                                                <asp:ListItem Text="Active" Value="Active" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Text="Inactive" Value="Inactive" />
                                                            </asp:DropDownList>

                                                        </div>
                                                    </div>

                                                    <div class="w-full">
                                                        <label class="text-gray-500 text-sm font-medium">User Name</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox ID="txtusername" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="3" runat="server" ></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="mt-4 flex items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                    <div class="w-full">
                                                        <label class="text-gray-500 text-sm font-medium">Dept</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox ID="txtdept" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="6" runat="server" ></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="w-full">
                                                        <label class="text-gray-500 text-sm font-medium">Mobile</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox ID="txtmobile" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="6" runat="server" ></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="w-full"></div>
                                                </div>

                                                <div class="row">
                                                    <div class="col-sm-12">
                                                        <center>
                                                            <div id="Div1" runat="server" class="flex justify-between gap-4 md:flex-nowrap flex-wrap mt-6">
                                                                <asp:Button ID="BtnCancel" runat="server" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full" OnClick="BtnCancel_Click" Text="Reset" TabIndex="22" />
                                                                <asp:Button ID="BtnSave" runat="server" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" ValidationGroup="ItemMasterValidation" OnClick="BtnSave_Click" Text="Save" TabIndex="21" />
                                                            </div>
                                                        </center>
                                                    </div>
                                                </div>

                                            </div>

                                            <div role="tabpanel" class="tab-pane fade in active" id="Party">

                                                <h3 class="text-2xl sa700 leading-normal text-gray-800 mt-5 mb-5" style="font-size: 20px;">PORTAL ACCESS</h3>

                                                <div class="flex md:justify-between gap-4 mt-6 md:flex-nowrap flex-wrap">
                                                    <div class="w-full">
                                                        <h2 class="text-lg sa700 leading-[18px] text-gray-800 mb-4">Roles Assigned</h2>
                                                        <div class="flex gap-5 flex-wrap md:max-w-[740px] w-full md:justify-between">
                                                            <div class="md:max-w-[200px] w-full">
                                                                <div class="flex gap-4 items-center">
                                                                    <asp:CheckBox ID="ChkAccAd" runat="server" TabIndex="7" />
                                                                    <label for="ChkOverrExgRate" class="text-gray-500 text-sm font-medium">TD Account Administrator</label>
                                                                </div>
                                                            </div>
                                                            <div class="md:max-w-[200px] w-full">
                                                                <div class="flex gap-4 items-center">
                                                                    <asp:CheckBox ID="ChkDocAd" runat="server" TabIndex="9" />
                                                                    <label for="ChkRefDoc" class="text-gray-500 text-sm font-medium">TD B2B Doc Administrator</label>
                                                                </div>
                                                            </div>
                                                            <div class="md:max-w-[200px] w-full">
                                                                <div class="flex gap-4 items-center">
                                                                    <asp:CheckBox ID="ChkDataEC" runat="server" TabIndex="8" OnCheckedChanged="ChkDataEC_CheckedChanged" AutoPostBack="true" />
                                                                    <label for="ChkSupplyIndicator" class="text-gray-500 text-sm font-medium">TD Data Entry Clerk</label>
                                                                </div>
                                                            </div>

                                                            <div class="md:max-w-[200px] w-full">
                                                                <div class="flex gap-4 items-center">
                                                                    <asp:CheckBox ID="chkDec" runat="server" TabIndex="8" OnCheckedChanged="chkDec_CheckedChanged" AutoPostBack="true" />
                                                                    <label for="ChkSupplyIndicator" class="text-gray-500 text-sm font-medium">TD Declarant</label>
                                                                </div>
                                                            </div>

                                                            <div class="md:max-w-[200px] w-full">
                                                                <div class="flex gap-4 items-center">
                                                                    <asp:CheckBox ID="ChkOpManager" runat="server" TabIndex="8" />
                                                                    <label for="ChkSupplyIndicator" class="text-gray-500 text-sm font-medium">TD Operations Manager</label>
                                                                </div>
                                                            </div>
                                                            <div class="md:max-w-[200px] w-full"></div>
                                                            <div class="md:max-w-[200px] w-full"></div>

                                                        </div>
                                                    </div>
                                                    <!--  -->
                                                </div>

                                                    <div class="row">
                                                        <div class="col-sm-12" id="test" runat="server" visible="false">
                                                            
                                                            <div class="flex md:justify-between gap-4 mt-6 md:flex-nowrap flex-wrap">
                                                                <div class="w-full">
                                                                    <h2 class="text-lg sa700 leading-[18px] text-gray-800 mb-4">Group</h2>
                                                                    <div class="flex gap-5 flex-wrap md:max-w-[740px] w-full md:justify-between">
                                                                        <div class="md:max-w-[200px] w-full">
                                                                            <div class="flex gap-4 items-center">
                                                                                <asp:CheckBox ID="CheckBox1" runat="server" TabIndex="7" />
                                                                                <label for="ChkOverrExgRate" class="text-gray-500 text-sm font-medium">Air Export</label>
                                                                            </div>
                                                                        </div>
                                                                        <div class="md:max-w-[200px] w-full">
                                                                            <div class="flex gap-4 items-center">
                                                                                <asp:CheckBox ID="CheckBox2" runat="server" TabIndex="9" />
                                                                                <label for="ChkRefDoc" class="text-gray-500 text-sm font-medium">Air Import</label>
                                                                            </div>
                                                                        </div>
                                                                        <div class="md:max-w-[200px] w-full">
                                                                            <div class="flex gap-4 items-center">
                                                                                <asp:CheckBox ID="CheckBox3" runat="server" TabIndex="8" AutoPostBack="true" />
                                                                                <label for="ChkSupplyIndicator" class="text-gray-500 text-sm font-medium">Aviation Dept</label>
                                                                            </div>
                                                                        </div>

                                                                        <div class="md:max-w-[200px] w-full">
                                                                            <div class="flex gap-4 items-center">
                                                                                <asp:CheckBox ID="CheckBox4" runat="server" TabIndex="8" OnCheckedChanged="chkDec_CheckedChanged" AutoPostBack="true" />
                                                                                <label for="ChkSupplyIndicator" class="text-gray-500 text-sm font-medium">Marine Dept</label>
                                                                            </div>
                                                                        </div>

                                                                        <div class="md:max-w-[200px] w-full">
                                                                            <div class="flex gap-4 items-center">
                                                                                <asp:CheckBox ID="CheckBox5" runat="server" TabIndex="8" />
                                                                                <label for="ChkSupplyIndicator" class="text-gray-500 text-sm font-medium">PROM</label>
                                                                            </div>
                                                                        </div>
                                                                        <div class="md:max-w-[200px] w-full"></div>
                                                                        <div class="md:max-w-[200px] w-full"></div>

                                                                    </div>
                                                                </div>
                                                                <!--  -->
                                                            </div>

                                                        </div>
                                                        <div class="col-sm-12" id="test1" runat="server" visible="false">
                                                            <div class="flex md:justify-between gap-4 mt-6 md:flex-nowrap flex-wrap">
                                                                    <div class="w-full">
                                                                        <div class="flex gap-5 flex-wrap md:max-w-[740px] w-full md:justify-between">
                                                                            <div class="md:max-w-[200px] w-full">
                                                                                <div class="flex gap-4 items-center">
                                                                                    <asp:CheckBox ID="CheckBox6" runat="server" TabIndex="7" />
                                                                                    <label for="ChkOverrExgRate" class="text-gray-500 text-sm font-medium">Sea Export</label>
                                                                                </div>
                                                                            </div>
                                                                            <div class="md:max-w-[200px] w-full">
                                                                                <div class="flex gap-4 items-center">
                                                                                    <asp:CheckBox ID="CheckBox7" runat="server" TabIndex="9" />
                                                                                    <label for="ChkRefDoc" class="text-gray-500 text-sm font-medium">Sea Import</label>
                                                                                </div>
                                                                            </div>
                                                                            <div class="md:max-w-[200px] w-full">
                                                                                <div class="flex gap-4 items-center">
                                                                                    <asp:CheckBox ID="CheckBox8" runat="server" TabIndex="8" AutoPostBack="true" />
                                                                                    <label for="ChkSupplyIndicator" class="text-gray-500 text-sm font-medium">kaizen</label>
                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                    </div>
                                                                    <!--  -->
                                                                </div>

                                                        </div>
                                                        <hr />
                                                    </div>

                                                <div runat="server" id="DecDtl" visible="false" >
                                                    <div class="mt-4 flex items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                        <div class="w-full">
                                                             <label class="text-gray-500 text-sm font-medium">TradeNet Mailbox</label>
                                                             <div class="relative mt-1">
                                                                 <asp:DropDownList ID="DrpMailbox" CssClass="drop w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"                              OnSelectedIndexChanged="DrpMailbox_SelectedIndexChanged" AutoPostBack="true" TabIndex="13" runat="server"></asp:DropDownList>
                                                             </div>
                                                         </div>

                                                        <div class="w-full">
                                                            <label class="text-gray-500 text-sm font-medium">Declarant Code</label>
                                                            <div class="relative mt-1">
                                                                <asp:TextBox ID="TxtDecCompCode" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="6" runat="server" ></asp:TextBox>
                                                            </div>
                                                        </div>

                                                        <div class="w-full">
                                                            <label class="text-gray-500 text-sm font-medium">Declarant Name</label>
                                                            <div class="relative mt-1">
                                                                <asp:TextBox ID="TxtDecName" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="6" runat="server" ></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="mt-4 flex items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                        <div class="w-full">
                                                            <label class="text-gray-500 text-sm font-medium">Declarant Company UEI</label>
                                                            <div class="relative mt-1">
                                                                <asp:TextBox ID="TxtDecCompCRUEI" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="6" runat="server" ></asp:TextBox>
                                                            </div>
                                                        </div>

                                                        <div class="w-full">
                                                            <label class="text-gray-500 text-sm font-medium">Declarant Company Name</label>
                                                            <div class="relative mt-1">
                                                                <asp:TextBox ID="TxtDecCompName" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="6" runat="server" ></asp:TextBox>
                                                            </div>
                                                        </div>

                                                        <div class="w-full">
                                                            <label class="text-gray-500 text-sm font-medium">Declarant Telephone</label>
                                                            <div class="relative mt-1">
                                                                <asp:TextBox ID="TxtDecTel" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="6" runat="server" ></asp:TextBox>
                                                            </div>
                                                        </div>

                                                    </div>

                                                    <div class="mt-4 flex items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                        <div class="w-full">
                                                            <label class="text-gray-500 text-sm font-medium">Declarant Sequence Pool</label>
                                                            <div class="relative mt-1">
                                                                <asp:DropDownList ID="DrpDecPool" CssClass="drop w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="13" runat="server"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>

                                                </div>
                                    
                                                <div class="mt-4 flex items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                    <h3 class="text-2xl sa700 leading-normal text-gray-800 mt-5" style="font-size: 20px;">VIEW PREFERENCES</h3>
                                                </div>

                                                <div class="mt-4 flex gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                    
                                                    <div class="w-full add_label_style">
                                                        <h3 class="text-2xl sa700 leading-normal text-gray-800 mt-5 mb-5" style="font-size: 16px;">In</h3>
                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                                                            <ContentTemplate>
                                                            
                                                            <asp:CheckBoxList ID="ChkBoxListInPayment" runat="server" OnSelectedIndexChanged="ChkBoxListInPayment_SelectedIndexChanged" OnTextChanged="ChkBoxListInPayment_TextChanged" AutoPostBack="true" ItemStyle-HorizontalPadding="10"  ></asp:CheckBoxList>
                                                                </ContentTemplate>
                                                        </asp:UpdatePanel>

                                                     </div>

                                                    <div class="w-full add_label_style">
                                                        <h3 class="text-2xl sa700 leading-normal text-gray-800 mt-5 mb-5" style="font-size: 16px;">InNon</h3>
                                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
                                                            <ContentTemplate>
                                                                                                    <asp:CheckBoxList ID="ChkBoxListInnonPayment" runat="server"  OnSelectedIndexChanged="ChkBoxListInnonPayment_SelectedIndexChanged" OnTextChanged="ChkBoxListInnonPayment_TextChanged" AutoPostBack="true" ></asp:CheckBoxList>
                                                                </ContentTemplate>
                                                         </asp:UpdatePanel>

                                                     </div>


                                                    <div class="w-full add_label_style">
                                                        <h3 class="text-2xl sa700 leading-normal text-gray-800 mt-5 mb-5" style="font-size: 16px;">Out</h3>
                                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always">
                                                            <ContentTemplate>
                                                                                                    <asp:CheckBoxList ID="ChkBoxListOut" runat="server"  ></asp:CheckBoxList>
                                                            </ContentTemplate>
                                                                                                            </asp:UpdatePanel>

                                                        </div>


                                                    <div class="w-full add_label_style">
                                                        <h3 class="text-2xl sa700 leading-normal text-gray-800 mt-5 mb-5" style="font-size: 16px;">Transhipment</h3>
                                                        <asp:CheckBoxList ID="ChkBoxListTrans" runat="server"  ></asp:CheckBoxList>

                                                        </div>

                                                    <div class="w-full add_label_style">
                                                        <h3 class="text-2xl sa700 leading-normal text-gray-800 mt-5 mb-5" style="font-size: 16px;">Co</h3>
                                                        <asp:CheckBoxList ID="ChkBoxListCo" runat="server"  ></asp:CheckBoxList>

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

</asp:Content>
