<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="HelloWorld.aspx.vb" Inherits="Project_WorkingFile_Nicole.HelloWorld" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <p>
        Welcome to the wonderful world of GitHub and SourceTree!
        <br />
        <br />
        &nbsp;<asp:Button ID="btnClick" runat="server" Text="Click Me" />
        <br />
        <br />
        <asp:Label ID="lblMessage" runat="server" Text="[]"></asp:Label>
        <br />
        </p>
    </form>
</body>
</html>
