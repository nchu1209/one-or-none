<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/CustomerMaster.Master" CodeBehind="CustomerPortfolioDetail.aspx.vb" Inherits="KProject.CustomerPortfolioDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <link rel="shortcut icon" href="/favicon-4.ico" type="image/x-icon" />
    <link rel="shortcut icon" href="http://localhost:51539/EmployeeManageCustomers.aspx" />
    <link href="ContentStyle.css" rel="stylesheet" type="text/css" />
    
       

    
    <div id ="title">
        Portfolio Detail
        <br />
        <div id="content">
            <asp:Label ID="lblPortfolioStatus" runat="server"></asp:Label>
        </div>
        <span style="font-weight: normal; font-family: Arial; font-size: medium">sum of these two portions constitutes the total value of a portfolio.</span><br />
              <span style="font-weight: normal; font-family: Arial; font-size: medium">there rshould be a select or ddl on top for the custoemrs to select which stock portfolio they want to look at</span><br />
         <span style="font-family: Arial; font-size: medium; font-weight: normal">Customers can create a new stock portfolio through an option on their home page (after they login).
    </span>
    </div>


    <div id="lefthalf">
        <div id ="subtitle">
            Cash-Value Portion
            <br />
            <div id="content">

                The cash-value portion is where gains, fees, bonuses, and available cash (that can be used to purchase more stock) are located

                <br />
                current value of each stock<br />
                transacction fees<br />
                - Fees are listed as separate transactions in the cash-value portion of the portfolio, and have the description “Fee: [Stock name]”<br />
                any gains from previous sales of stock<br />
                any bonuses previous applied to the portfolio<br />
                any available cash<br />
                any other transactions<br />
                total value<br />
                total fees<br />
                <br />
                o The portfolio should be updated as follows: • Each sale should be listed under the cash-value portion of the portfolio with the following fields: • Type: Deposit • Amount: current value of the shares of stock sold • Description: should include which stock was sold, the number of shares sold, initial stock price, current stock price, and total gains/losses • Transaction fees should be deducted from the cash-value portion of the portfolio and listed as “Type: “Fee” and Description: “Fee for sale of [stock name]”. </div>
        </div>
    </div>


    <div id="righthalf">
        <div id ="subtitle">
            Stock Portion
            <br />
            <div id="content">

              shows the number of shares and purchase price of stocks in a portfolio.
                #of shares
                purchase price of stocks

            </div>
             </div>
        </div>




</asp:Content>
