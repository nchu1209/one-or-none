<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EmployeeLogin.aspx.vb" Inherits="KProject.EmployeeLogin" %>

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
    </style>
</head>
<body>
    <form id="form1" runat="server">
    
    
    
        <div id="lefttopcorner">
            <img class="auto-style1" src="Petunia2.jpg" /><br />
            <br />
            <br />
        </div>
       
   <div id ="title">
        Welcome Employees!
    </div>

        <div id="employeeloginright">

            <br />
            <br />
            Employee ID
            <br />
            <asp:TextBox ID="txtEmployeeID" runat="server"></asp:TextBox>
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
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            <asp:Label ID="lblError" runat="server" Text=""></asp:Label>

        </div>
    </form>
</body>
</html>
