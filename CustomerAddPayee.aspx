<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/CustomerMaster.Master" CodeBehind="CustomerAddPayee.aspx.vb" Inherits="KProject.CustomerAddPayee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="ContentStyle.css" rel="stylesheet" type="text/css" />
    <div id ="title">
        Add Payee
        <br />
        <br />
    </div>
    <div id ="lefthalf">
        <div id ="subtitle">Add Existing Payee</div>
        <br />
        <div id ="label">
            <asp:Label ID="Label1" runat="server" Text="Choose Payee:"></asp:Label>
            <br />
            <br />
        </div>
        <div id ="textbox">
            <asp:DropDownList ID="ddlPayee" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="btnAddPayee" runat="server" Text="Add Payee" />
            <br />
        </div>
    </div>
    <div id ="righthalf">
        <div id ="subtitle">Create New Payee</div>
        <br />
        <br />
        <br />
        <br />
    </div>
</asp:Content>
