<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/CustomerMaster.Master" CodeBehind="CustomerPayBills.aspx.vb" Inherits="KProject.CustomerPayBills" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="ContentStyle.css" rel="stylesheet" type="text/css" />
    <div id ="title">
        Pay Bills<br />
        <br />
    </div>
    <div id ="lefthalf">
        <div id ="subtitle">Your Payees</div>
        <br />
        <asp:GridView ID="gvCustomersPayees" runat="server"></asp:GridView>
        <br />
        <br />
        <br />
    </div>
    <div id ="righthalf">
        <div id ="subtitle">Make a Payment</div>
        <br />
        <div id="label">
            <asp:Label ID="Label1" runat="server" Text="Payee:"></asp:Label>
            <br />

            <asp:Label ID="Label2" runat="server" Text="Amount:"></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Date:"></asp:Label>
            <br />
            <br />
            <br />
        </div>
        <div id ="textbox">
            <asp:DropDownList ID="ddlPayee" runat="server">
            </asp:DropDownList>
            <br />
            <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ClientIDMode="Static" ControlToValidate="txtAmount" ErrorMessage="Please enter a payment amount.">*</asp:RequiredFieldValidator>
            <br />
            <asp:Calendar ID="calDate" runat="server"></asp:Calendar>
            <br />
            <asp:Button ID="txtPay" runat="server" Text="Pay" />
            <br />
            <br />
            <asp:Label ID="lblMessage" runat="server" Text="[]"></asp:Label>
            <br />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            <br />
        </div>
        <br />
      

    </div>
</asp:Content>
