 <%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/CustomerMaster.Master" CodeBehind="CustomerHome.aspx.vb" Inherits="KProject.CustomerHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="ContentStyle.css" rel="stylesheet" type="text/css" />
     <link rel="shortcut icon" href="/favicon-4.ico" type="image/x-icon" />
    <link rel="shortcut icon" href="http://localhost:51539/CustomerHome.aspx" />
    <div id ="title">
        Customer Home
        <br />
        <br />
    </div>
    <div id ="subtitle">
        My Accounts
    </div>
    <div id="accountsubtitleleft">
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />

    </div>
    <asp:Panel ID="Checking" runat="server">
    <div id="accountsubtitle">
        <asp:Label ID="Label1" runat="server" Text="Checking Account Number(s): "></asp:Label>
        <asp:Label ID="lblCheckingAccount" runat="server"></asp:Label>
    </div>
     </asp:Panel>


    <asp:Panel ID="Savings" runat="server">
    <div id="accountsubtitle">
            <asp:Label ID="Label2" runat="server" Text="Savings Account Number(s): "></asp:Label>
            <asp:Label ID="lblSavingsAccount" runat="server"></asp:Label>
    </div>
    </asp:Panel>


    <asp:Panel ID="IRA" runat="server">
    <div id="accountsubtitle">
            <asp:Label ID="Label3" runat="server" Text="IRA Account Number: "></asp:Label>
            <asp:Label ID="lblIRAAccount" runat="server"></asp:Label>
    </div>
    </asp:Panel>

    <asp:Panel ID="Stock" runat="server">
        <div id="accountsubtitle">

            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>

            <asp:Label ID="lblStockAccount" runat="server"></asp:Label>

    </div>
    </asp:Panel>


    <div id="accountsubtitleleft">

        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />

    </div>

    <div id="accountsubtitle">
        <asp:GridView runat="server" ID="gvAccounts" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
    </div>

</asp:Content>
