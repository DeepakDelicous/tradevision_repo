<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="UserCreate.aspx.cs" Inherits="RET.UserCreate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">   
 <div class="col-sm-10">
                <section class="bg">
                    <div class="container">
                        <div class="row" style=" -webkit-box-shadow: 0 6px 12px rgba(0,0,0,.175);   box-shadow: 0 6px 12px rgba(0,0,0,.175);  -moz-box-shadow: 0 6px 12px rgba(0,0,0,.175);  background-clip: padding-box;  ">
                            <div class="board">
                                <!-- <h2>Welcome to IGHALO!<sup>™</sup></h2>-->
                                <div class="board-inner "  >
                                                                        <div>

                                        <!-- Nav tabs -->
                                        <ul class="nav nav-tabs" id="myTab" style="margin-top: -60px;" role="tablist">
                                            <div class="liner"></div>
                                            <li class="active">
                                                <a href="#Header" data-toggle="tab" title="Account Details">
                                                    <span class="round-tabs one">
                                                        <i class="glyphicon glyphicon-home" ></i>
                                                    </span>
                                                </a></li>
                                            <li><a href="#Party" data-toggle="tab" title="Trade Declaration Portal">
                                                <span class="round-tabs two">
                                                    <i class="glyphicon glyphicon-user"></i>
                                                </span>
                                            </a>
                                            </li>
                                            <li><a href="#Cargo" data-toggle="tab" title="Forwarder Portal">
                                                <span class="round-tabs three">
                                                    <i class="glyphicon glyphicon-plane"></i>
                                                </span></a>
                                            </li>

                                            <li><a href="#Invoice" data-toggle="tab" title="Shipper Portal">
                                                <span class="round-tabs four">
                                                    <i class="glyphicon glyphicon-file"></i>
                                                </span>
                                            </a></li>

                                            <li><a href="#Item" data-toggle="tab" title="Consignee Portal">
                                                <span class="round-tabs five">
                                                    <i class="glyphicon glyphicon-list-alt"></i>
                                                </span></a>
                                            </li>
                                        </ul>
                                        <!-- Tab panes -->
                                        <center> 

  <div class="tab-content"  style="margin-top:-45px;">

        
    <div role="tabpanel" class="tab-pane fade in active" id="Header">
        <br />
        Account Details
    </div>
           
    <div role="tabpanel" class="tab-pane fade" id="Party"  >
         <br />
        Trade Declaration Portal
    </div>
    <div role="tabpanel" class="tab-pane fade" id="Cargo">                           
        <br />
        Forwarder Portal
    </div>
    <div role="tabpanel" class="tab-pane fade" id="Invoice">          
       <br />                 
        Shipper Portal
   </div>
  
      <div role="tabpanel" class="tab-pane fade" id="Item">                                         
          <br />
          Consignee Poratl
      </div>                             
        
              </div>
              </center>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </section>

            </div>
</asp:Content>
