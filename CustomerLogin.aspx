<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CustomerLogin.aspx.vb" Inherits="KProject.CustomerLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Longhorn Bank</title>
    <link rel="shortcut icon" href="/favicon-4.ico" type="image/x-icon" />
    <link rel="shortcut icon" href="http://localhost:51539/CustomerLogin.aspx" />
    <link href="ContentStyle.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            width: 233px;
            height: 83px;
        }
        .auto-style2 {
            font-size: x-large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Panel ID="pnlLogin" runat="server">
        <div id="lefttopcorner">
            <img class="auto-style1" src="Petunia2.jpg" /><br />
            <br />
            <br />
            <br />
            Email
            <br />
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ClientIDMode="Static" ControlToValidate="txtEmail" ErrorMessage="Invalid email address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
            <br />
            Password
            <br />
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ClientIDMode="Static" ControlToValidate="txtEmail" ErrorMessage="Password is Required">*</asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Button ID="btnLogin" runat="server" Text="Login" />
            <br />
            <br />
            <br />
            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" PostBackUrl="~/CustomerCreateAccount.aspx">Apply for an Account!</asp:LinkButton>
            <br />
            <br />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            <br />
        </div>
       
        <div id="rightcornertitle">
            <div id="title">
                <br />
                Welcome to Longhorn Bank!
                <br />
            </div>
        </div>

        <div id="rightcornercontent">
             <div id="a">
                 <br />
                 Checking Accounts<br />
            <br />
                 <br />
                 <br />
                 <br />
            <br />
                 <br />
                 <br />
                 <br />
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

         <div id="b">
             <br />
             Savings Accounts<br />
            <br />
             <br />
             <br />
             <br />
             <br />
             <br />
             <br />
             <br />
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
             <div id="c">
                 <br />
                 IRAs<br />
                 <br />
                 <br />
                 <br />
                 <br />
                 <br />
                 <br />
                 <br />
                 <br />
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
             <div id="d">
                 <br />
                 Stock Portfolios<br />
                 <br />
                 <br />
                 <br />
                 <br />
                 <br />
                 <br />
                 <br />
                 <br />
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


             <br />


             <br />


        </div>


         <div id="footer">
        <br />
        <br />
             <br />
        Website Created by One or None, Ltd.
        <br />
        Group 3: Leah Carroll, Nicole Chu, Amy Enrione, Catherine King
             </div>

        </asp:Panel>


        <asp:Panel ID="pnlNoLongerCustomer" runat="server">
            <br />
            <img alt="" class="auto-style1" src="Petunia2.jpg" />
            <br/>
            <br/>
            <div id="contentBIG" class="auto-style2">
                   Hello
            <asp:Label ID="lblDisabled" runat="server" Text=""></asp:Label>
                </div>

             <div id="footer">
                 <br />
                 <br />
                 <br />
                 <br />
                      <br />
                 <br />
                      <br />
                 <br />
                      <br />
                 <br />
        Website Created by One or None, Ltd.
        <br />
        Group 3: Leah Carroll, Nicole Chu, Amy Enrione, Catherine King
             </div>
        </asp:Panel>
     
        <br />
        <br />

        
    

    </form>
  

 
  

    </body>
</html>
