﻿ <%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/CustomerMaster.Master" CodeBehind="CustomerHome.aspx.vb" Inherits="KProject.CustomerHome" %>
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
    

   

    <div id="accountsubtitle">
        <asp:GridView ID="gvAccounts" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Account Number" HeaderText="Account Number" ReadOnly="True" SortExpression="Account Number">
                <HeaderStyle Width="150px" HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:HyperLinkField HeaderText="Account Name" SortExpression="AccountName" DataNavigateUrlFields="AccountNumber" DataNavigateUrlFormatString="CustomerTransactionSearch.aspx" DataTextField="AccountName">
                    <%--<EditItemTemplate>--%>
                  <%--      <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("AccountName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("AccountName") %>'></asp:Label>
                    </ItemTemplate>--%>
                    <HeaderStyle HorizontalAlign="Center" Width="150px" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:HyperLinkField>
                <asp:BoundField DataField="AccountType" HeaderText="Account Type" SortExpression="AccountType" >
                <HeaderStyle Width="150px" HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Balance" HeaderText="Balance" SortExpression="Balance" DataFormatString="{0:$###,###.00}" >
                <FooterStyle HorizontalAlign="Center" />
                <HeaderStyle Width="90px" HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
            </Columns>
            <EditRowStyle BackColor="#2461BF" HorizontalAlign="Center" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MIS333K_msbck614ConnectionString %>" SelectCommand="usp_accounts_get_last_four" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:SessionParameter Name="CustomerNumber" SessionField="CustomerNumber" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>

</asp:Content>
