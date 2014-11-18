<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/CustomerMaster.Master" CodeBehind="CustomerCreateBankAccount.aspx.vb" Inherits="KProject.CustomerCreateBankAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link rel="shortcut icon" href="/favicon-4.ico" type="image/x-icon" />
    <link rel="shortcut icon" href="http://localhost:51539/CustomerCreateBankAccount.aspx" />
     <div id ="title">
        Create a Bank Account
         <br />
    
    </div>

     <div id="center">
    
        <br />
        <br />
        <br />
       
        <%-- Make sure to not have the 2 accounts the same --%>
        <%-- because the money comes from an outside source, any amount is allowed --%>
        
         <div id ="label">
             <asp:Label ID="Label3" runat="server" Text="Account type: "></asp:Label>
             <br />
            <br />
              <asp:Label ID="Label1" runat="server" Text="Account Name: "></asp:Label>
             <br />
             <br />

             <asp:Label ID="Label2" runat="server" Text="Account Number: "></asp:Label>
             <br />
             <br />

             <asp:Label ID="Label7" runat="server" Text="Initial Deposit:"></asp:Label>
             <br />
             <br />
             <%-- Default to Current Date --%>
             <br />
             <br />
             
             <br />
             <br />
             <br />
          </div>
        
             <div id="textbox">
                  <asp:DropDownList ID="ddlBankAccounts" runat="server" AutoPostBack="True">
            <asp:ListItem>Pick an account type</asp:ListItem>
            <asp:ListItem>Checking Account</asp:ListItem>
            <asp:ListItem>Savings Account</asp:ListItem>
            <asp:ListItem>Individual Retirement Account</asp:ListItem>
            <asp:ListItem>Stock Portfolio</asp:ListItem>
        </asp:DropDownList>
                 <br />
                <br />
                 <asp:TextBox ID="txtAccountName" runat="server"></asp:TextBox>
                 <br />
                   <br />
                 <asp:TextBox ID="txtAccountNumber" runat="server" ReadOnly="True"></asp:TextBox>
              
                 <br />
                 <br />
                 <asp:TextBox ID="txtInitialDeposit" runat="server"></asp:TextBox>
              
                 <br />
                 <br />
             
                 <br />
                 <br />
                 <br />
                 <br />
                 <br />
                 <br />
                  <br />
        
             </div>
             
             

        
             

        
        </asp:Panel>


        <br />
        <br />

    </div>

</asp:Content>
