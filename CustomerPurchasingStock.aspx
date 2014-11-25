<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/CustomerMaster.Master" CodeBehind="CustomerPurchasingStock.aspx.vb" Inherits="KProject.CustomerPurchasingStock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    -	When customers are selecting a stock to purchase, they should see the stock’s name, type (index fund, ordinary stock, etc.), current share price, and any fees that apply to the stock in question.
    -	On the same page used to select the stock, customers will enter the number of shares they wish to purchase. 
-	They will also see a listing of their other accounts (checking, savings, and the cash-value of their portfolio) and their current balances. Customers must select which of their other accounts the funds will come from.
-	As with all other banking transactions, the customer must enter a date for the stock purchase.
-	After making these selections, customers will submit their stock purchase order. 
o	If they do not have enough money to make the purchase, the transaction is not processed and they should see a descriptive error message.
o	If the transaction is successful, the money should be withdrawn from the selected account, and the transaction should be listed as Type: “Withdrawal” and Description: “Stock Purchase – Account [Stock Portfolio Account Number]”
o	A successful transaction should also result in a descriptive confirmation message.
o	Once a transaction is processed, the customer should receive a completion message and have the option to return to their portfolio detail page, where they should see all stocks in the portfolio, including the one they just purchased. 
</asp:Content>