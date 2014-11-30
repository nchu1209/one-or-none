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
            <strong>Search by Description:</strong><br />
&nbsp;<asp:TextBox ID="txtDescriptionSearch" runat="server"></asp:TextBox>
           <div id="content2">
           <div id="radiobuttonfix">
             <asp:RadioButtonList ID="rblDescription" runat="server" style="text-align: left">
                <asp:ListItem>Partial Search</asp:ListItem>
                <asp:ListItem>Keyword Search</asp:ListItem>
            </asp:RadioButtonList>
               </div>
                </div>
        </div>
        

        <div id="b1">
            <strong>Search by Transaction Type:
            </strong>
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
            <strong>Search by Price:</strong><br />
            <div id="content2">
               <div id="radiobuttonfix">
            <asp:RadioButtonList ID="rblPrice" runat="server" style="text-align: left">
                <asp:ListItem>0-$100</asp:ListItem>
                <asp:ListItem>101 - $200</asp:ListItem>
                <asp:ListItem>201 - $300</asp:ListItem>
                <asp:ListItem>$300+</asp:ListItem>
                <asp:ListItem>Other</asp:ListItem>
            </asp:RadioButtonList>
                   </div>
                </div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            Between 
            <asp:TextBox ID="txtSearchByOtherPriceMin" runat="server" Width="65px"></asp:TextBox>
            And
            <asp:TextBox ID="txtSearchByOtherPriceMax" runat="server" Width="65px"></asp:TextBox>
            <br />
            <br />
            <br />
        </div>


        <div id="d1">
            <strong>Search by Transaction Number:</strong><br />
&nbsp;<asp:TextBox ID="txtSearchByTransactionNumber" runat="server" Width="166px"></asp:TextBox>
        </div>


        <div id="e1">
            <strong>Search by Date:</strong><br />
            <div id="content2">
               <div id="radiobuttonfix">
            <asp:RadioButtonList ID="rblDate" runat="server" style="text-align: left">
                <asp:ListItem>Last 15 Days</asp:ListItem>
                <asp:ListItem>Last 30 Days</asp:ListItem>
                <asp:ListItem>Last 60 Days</asp:ListItem>
                <asp:ListItem>All Available</asp:ListItem>
                <asp:ListItem>Custom Date Range</asp:ListItem>
            </asp:RadioButtonList>
                   </div>
                </div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            Last 
            <asp:TextBox ID="txtCustomDateSearch" runat="server" Width="46px"></asp:TextBox>
            Days
            <br />
            <br />
            <br />
        </div>


        <div id ="footer">
           <div id="a1">
           <div id="radiobuttonfix">
             <asp:RadioButtonList ID="rblDescriptionAO" runat="server" style="text-align: left">
                <asp:ListItem>And</asp:ListItem>
                <asp:ListItem>Or</asp:ListItem>
                <asp:ListItem>Do not include description in this search</asp:ListItem>
            </asp:RadioButtonList>
               </div>
                </div>
           <div id="b1">
           <div id="radiobuttonfix">
             <asp:RadioButtonList ID="rblTransactionTypeAO" runat="server" style="text-align: left">
                <asp:ListItem>And</asp:ListItem>
                <asp:ListItem>Or</asp:ListItem>
                <asp:ListItem>Do not include transaction type in this search</asp:ListItem>
            </asp:RadioButtonList>
               </div>
                </div>
           <div id="c1">
           <div id="radiobuttonfix">
             <asp:RadioButtonList ID="rblPriceAO" runat="server" style="text-align: left">
                <asp:ListItem>And</asp:ListItem>
                <asp:ListItem>Or</asp:ListItem>
                <asp:ListItem>Do not include price in this search</asp:ListItem>
            </asp:RadioButtonList>
               </div>
                </div>
           <div id="d1">
           <div id="radiobuttonfix">
             <asp:RadioButtonList ID="rblTransactionNumberAO" runat="server" style="text-align: left">
                <asp:ListItem>And</asp:ListItem>
                <asp:ListItem>Or</asp:ListItem>
                <asp:ListItem>Do not include transaction number in this search</asp:ListItem>
            </asp:RadioButtonList>
               </div>
                </div>
           <div id="e1">
           <div id="radiobuttonfix">
             <asp:RadioButtonList ID="rblDateAO" runat="server" style="text-align: left">
                <asp:ListItem>And</asp:ListItem>
                <asp:ListItem>Or</asp:ListItem>
                <asp:ListItem>Do not include date in this search</asp:ListItem>
            </asp:RadioButtonList>
               </div>
                <br />
               <br />
                </div>
        </div>
        <div id="footer">
            <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                <asp:ListItem>Ascending</asp:ListItem>
                <asp:ListItem>Descending</asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <asp:Button ID="btnSearch" runat="server" Text="Search" />
            <asp:Button ID="btnClear" runat="server" Text="Clear Selections" />
            <br />
            <br />
&nbsp;<asp:Label ID="lblNumberOfTransactions" runat="server"></asp:Label>
            <br />
            <br />
            <asp:GridView ID="gvTransactionSearch" runat="server">
            </asp:GridView>
        </div>

   </form>
  
</body>
</html>