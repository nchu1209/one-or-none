<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/CustomerMaster.Master" CodeBehind="CustomerTransactionDetail.aspx.vb" Inherits="KProject.CustomerTransactionDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="ContentStyle.css" rel="stylesheet" type="text/css" />
    <div id ="title">
        Transaction Details<br />
        <br />
    </div>
    <div id ="center">
       <div id ="subtitle">Account Details</div>
       <div id ="label2">
           <asp:Label ID="lblCustomerID" runat="server" Text="Description:"></asp:Label>
           <br />
           <asp:Label ID="Label1" runat="server" Text="Transaction Type:"></asp:Label>
           <br />
           <asp:Label ID="Label10" runat="server" Text="Amount:"></asp:Label>
           <br />
           <asp:Label ID="Label11" runat="server" Text="Transaction Number:"></asp:Label>
           <br />
           
        </div>
        <div id ="textbox">
            <asp:TextBox ID="txtDescription" runat="server" ReadOnly="True"></asp:TextBox>
            <br />
             <asp:TextBox ID="txtTransactionType" runat="server" ReadOnly="True"></asp:TextBox>
            <br />
             <asp:TextBox ID="txtAmount" runat="server" ReadOnly="True"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtTransactionNumber" runat="server" ReadOnly="True"></asp:TextBox>

            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
       
    </div>
</asp:Content>
