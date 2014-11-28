<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/CustomerMaster.Master" CodeBehind="CustomerBillDetail.aspx.vb" Inherits="KProject.CustomerBillDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="ContentStyle.css" rel="stylesheet" type="text/css" />
    <div id ="title">
        eBill Details<br />
        <br />
    </div>
    <div id ="center">
        Wheee Bill ID = 

        <asp:Label ID="lblTest" runat="server" Text="[]"></asp:Label>

    </div>
</asp:Content>
