<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ManagerMaster.Master" CodeBehind="ManagerViewBills.aspx.vb" Inherits="KProject.ManagerViewBills" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="ContentStyle.css" rel="stylesheet" type="text/css" />
    <div id ="title">
        View eBills<br />
        <br />
    </div>
    <div id ="center">
        <asp:Button ID="btnViewAll" runat="server" Text="View All eBills" />
        <br />
        <br />
        <asp:GridView ID="gvBills" runat="server" AutoGenerateColumns="False" DataKeyNames="BillID" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="BillID" HeaderText="BillID" ReadOnly="True" SortExpression="BillID" />
                <asp:BoundField DataField="PayeeName" HeaderText="PayeeName" SortExpression="PayeeName" />
                <asp:BoundField DataField="PayeeType" HeaderText="PayeeType" SortExpression="PayeeType" />
                <asp:BoundField DataField="CustomerID" HeaderText="CustomerID" SortExpression="CustomerID" />
                <asp:BoundField DataField="CustomerName" HeaderText="CustomerName" ReadOnly="True" SortExpression="CustomerName" />
                <asp:BoundField DataField="BillAmount" HeaderText="BillAmount" SortExpression="BillAmount" />
                <asp:BoundField DataField="BillDate" HeaderText="BillDate" SortExpression="BillDate" />
                <asp:BoundField DataField="DueDate" HeaderText="DueDate" SortExpression="DueDate" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                <asp:BoundField DataField="Active" HeaderText="Active" SortExpression="Active" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MIS333K_msbck614ConnectionString %>" SelectCommand="usp_innerjoin_bill_customer_payee" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
        <br />
        <br />
        <br />

    </div>
</asp:Content>
