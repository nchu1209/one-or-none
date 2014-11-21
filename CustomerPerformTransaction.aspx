﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/CustomerMaster.Master" CodeBehind="CustomerPerformTransaction.aspx.vb" Inherits="KProject.CustomerPerformTransaction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link rel="shortcut icon" href="/favicon-4.ico" type="image/x-icon" />
    <link rel="shortcut icon" href="http://localhost:51539/CustomerPerformTransaction.aspx" />
    <link href="ContentStyle.css" rel="stylesheet" type="text/css" />
     <div id ="title">
        Perform Transaction
         <br />
         <br />
    </div>
    <div id="center">
        <asp:DropDownList ID="ddlTransactions" runat="server" AutoPostBack="True">
            <asp:ListItem>Pick a transaction type</asp:ListItem>
            <asp:ListItem>Withdrawal</asp:ListItem>
            <asp:ListItem>Deposit</asp:ListItem>
            <asp:ListItem>Transfer</asp:ListItem>
            <asp:ListItem>Bill</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <br />
       
        <%-- Make sure to not have the 2 accounts the same --%><%-- because the money comes from an outside source, any amount is allowed --%>
         <asp:Panel ID="TransferPanel" runat="server" Visible =" false">
         <div id ="label">
             <asp:Label ID="Label1" runat="server" Text="Transfer Amount: "></asp:Label>
             <br />

             <asp:Label ID="Label2" runat="server" Text="Transfer From: "></asp:Label>
             <br />

             <asp:Label ID="Label7" runat="server" Text="Transfer To: "></asp:Label>
             <br />
             <%-- Default to Current Date --%>
             <asp:Label ID="Label4" runat="server" Text="Date:"></asp:Label>
             <br />
             <br />
             
             <br />
             <br />
             <br />
          </div>
        
             <div id="textbox">
                 <asp:TextBox ID="txtAmoutTransfer" runat="server"></asp:TextBox>
             <br />
                 <asp:DropDownList ID="ddlFromAccount" runat="server">
             </asp:DropDownList>
                 <br />
              <%-- Make sure to not have the 2 accounts the same --%>
                 <asp:DropDownList ID="ddlTransferTo" runat="server">
                 </asp:DropDownList>
              
                 <br />
                 <asp:TextBox ID="txtTransferDate" runat="server"></asp:TextBox>
              
                 <br />
                 <br />
             
                 <asp:Calendar ID="TransferCalendar" runat="server"></asp:Calendar>
             
                 <br />
                 <br />
                 <br />
                 <br />
                 
             </div>
             
             

        
             

        
        </asp:Panel>


        <%-- because the money comes from an outside source, any amount is allowed --%>

<asp:Panel ID="DepositPanel" runat="server" Visible =" false">
         <div id ="label">
             <asp:Label ID="Label8" runat="server" Text="Deposit Amount: "></asp:Label>
             <br />

             <asp:Label ID="Label9" runat="server" Text="Deposit Into: "></asp:Label>
             <br />
             <asp:Label ID="Label10" runat="server" Text="Date:"></asp:Label>
             <br />
             <br />
             
          </div>
        
             <div id="textbox">
                 <asp:TextBox ID="txtDepositAmount" runat="server"></asp:TextBox>
             <br />
                 <asp:DropDownList ID="ddlDeposit" runat="server">
             </asp:DropDownList>
                 <br />
              <%-- Default to Current Date --%>
                  <asp:TextBox ID="txtDepositDate" runat="server"></asp:TextBox>
              
                 <br />
                 <br />
             
                 <asp:Calendar ID="DepositCalendar" runat="server"></asp:Calendar>
             
                 <br />
                 <asp:Button ID="btnDeposit" runat="server" Text="Confirm Deposit" />
                 <br />
                 <asp:Label ID="lblErrorDeposit" runat="server"></asp:Label>
                 <br />
                 <br />
             </div>
             
        </asp:Panel>





<asp:Panel ID="WithdrawalPanel" runat="server" Visible =" false">
         <br />
         <div id="label">

       <div id ="Div1">
             <asp:Label ID="Label13" runat="server" Text="Withdrawal Amount: "></asp:Label>
             <br />

             <asp:Label ID="Label14" runat="server" Text="Withdrawal From: "></asp:Label>
             <br />
             <%-- Default to Current Date --%>
             <asp:Label ID="Label15" runat="server" Text="Date:"></asp:Label>
             <br />
             <br />
           
          </div>
        


         </div>
        
             <div id="textbox">
                 <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
             <br />
                 <asp:DropDownList ID="DropDownList1" runat="server">
             </asp:DropDownList>
                 <br />
                <asp:TextBox ID="txtWithdrawalDate" runat="server"></asp:TextBox>
              
                 <br />
                 <br />
             
                 <asp:Calendar ID="WithdrawalCalendar" runat="server"></asp:Calendar>
                 
                 <br />
                 <br />
                 <br />
                 
             </div>
             

        
         <br />
         <br />
             

        
        </asp:Panel>



        <br />
        <br />



    </div>
    

     <br />
     <br />
     <br />
     <br />
     <br />
     <br />
    

</asp:Content>

