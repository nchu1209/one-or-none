<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/CustomerMaster.Master" CodeBehind="CustomerPurchasingStock.aspx.vb" Inherits="KProject.CustomerPurchasingStock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="title">
        Purchase Stocks
    </div>



    <br />
    <asp:GridView ID="gvPurchaseStocks" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="TickerSymbol" HeaderText="TickerSymbol" SortExpression="TickerSymbol" />
            <asp:BoundField DataField="StockType" HeaderText="StockType" SortExpression="StockType" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="SalesPrice" HeaderText="SalesPrice" SortExpression="SalesPrice" />
            <asp:BoundField DataField="Fee" HeaderText="Fee" SortExpression="Fee" />
            <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Quantity")%>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="txtQuantity" runat="server" Text='<%# Bind("Quantity")%>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [tblStocks]"></asp:SqlDataSource>
    <br />
    -	On the same page used to select the stock, customers will enter the number of shares they wish to purchase. 
    (TEXBOX IN GRIDVIEW)<br />
    <br />
    -	They will also see a listing of their other accounts (checking, savings, and the cash-value of their portfolio) and their current balances. Customers must select which of their other accounts the funds will come from.
    (DDL (like on customer perform transaction))<br />
    &nbsp;&nbsp;&nbsp;
    -	As with all other banking transactions, the customer must enter a date for the stock purchase.
    (again customer perform transaction page)<br />
    &nbsp;&nbsp;&nbsp;
    -	After making these selections, customers will submit their stock purchase order. 
    <br />
    o	If they do not have enough money to make the purchase, the transaction is not processed and they should see a descriptive error message.
    <br />
    o	If the transaction is successful, the money should be withdrawn from the selected account, and the transaction should be listed as Type: “Withdrawal” and Description: “Stock Purchase – Account [Stock Portfolio Account Number]”
    <br />
    o	A successful transaction should also result in a descriptive confirmation message.
    <br />
    o	Once a transaction is processed, the customer should receive a completion message and have the option to return to their portfolio detail page, where they should see all stocks in the portfolio, including the one they just purchased.  
    (redirect)  
</asp:Content>