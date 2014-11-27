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

       
        <div id="a">
            Search by Description:<br />
&nbsp;<asp:TextBox ID="txtDescriptionSearch" runat="server"></asp:TextBox>
           <div id="content2">
               <div id="radiobuttonfix">
             <asp:RadioButtonList ID="RadioButtonList1" runat="server" style="text-align: left">
                <asp:ListItem>Partial Search</asp:ListItem>
                <asp:ListItem>Keyword Search</asp:ListItem>
            </asp:RadioButtonList>
               </div>
                </div>
        </div>
        
        <div id="b">
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
        <div id="c">
            Search by Price:<br />
            <div id="content2">
               <div id="radiobuttonfix2">
            <asp:RadioButtonList ID="RadioButtonList2" runat="server" style="text-align: left">
                <asp:ListItem>0-$100</asp:ListItem>
                <asp:ListItem>101 - $200</asp:ListItem>
                <asp:ListItem>201 - $300</asp:ListItem>
                <asp:ListItem>$300+</asp:ListItem>
                <asp:ListItem>Other</asp:ListItem>
            </asp:RadioButtonList>
                   </div>
                </div>
            <asp:TextBox ID="txtSearchByOtherPrice" runat="server"></asp:TextBox>
        </div>
        <div id="d">
            Search by Transaction Number:<br />
&nbsp;<asp:TextBox ID="txtSearchByTransactionNumber" runat="server"></asp:TextBox>
        </div>

   </form>
  
</body>
</html>