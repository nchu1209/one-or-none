<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CustomerTransactionSearch.aspx.vb" Inherits="KProject.CustomerTransactionSearch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="ContentStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="title">
            <br />
            Transaction Search<br />
            <br />
            <asp:Label ID="lblAccountName" runat="server" Text=""></asp:Label>
            <br />
            <br />
        </div>

       
        <div id="a1">
            Search by Description:<br />
&nbsp;<asp:TextBox ID="txtDescriptionSearch" runat="server"></asp:TextBox>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                <asp:ListItem>Partial Search</asp:ListItem>
                <asp:ListItem>Keyword Search</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        
        <div id="b1">
            Search by Transaction Type:
            <br />
            <asp:DropDownList ID="ddlSearchByTransactionType" runat="server">
                <asp:ListItem>Deposit</asp:ListItem>
                <asp:ListItem>Withdrawal</asp:ListItem>
                <asp:ListItem>Transfer</asp:ListItem>
                <asp:ListItem>Payment</asp:ListItem>
                <asp:ListItem>Fee</asp:ListItem>
            </asp:DropDownList>
            <br />
        </div>
        <div id="c1">
            Search by Price:<br />
            <asp:RadioButtonList ID="RadioButtonList2" runat="server">
                <asp:ListItem>0-$100</asp:ListItem>
                <asp:ListItem>101 - $200</asp:ListItem>
                <asp:ListItem>201 - $300</asp:ListItem>
                <asp:ListItem>$300+</asp:ListItem>
                <asp:ListItem>Other</asp:ListItem>
            </asp:RadioButtonList>
            <asp:TextBox ID="txtSearchByOtherPrice" runat="server"></asp:TextBox>
        </div>
        <div id="d1">
            Search by Transaction Number:<br />
&nbsp;<asp:TextBox ID="txtSearchByTransactionNumber" runat="server"></asp:TextBox>
        </div>

   </form>
  
</body>
</html>