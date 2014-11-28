<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ManagerMaster.Master" CodeBehind="ManagerEditStocks.aspx.vb" Inherits="KProject.ManagerEditStocks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div id="title">
        Edit Stocks
    </div>
    <br/>

    <div id="content">



        <asp:GridView ID="gvStocks" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="TickerSymbol" HeaderText="TickerSymbol" SortExpression="TickerSymbol" />
                <asp:BoundField DataField="StockType" HeaderText="StockType" SortExpression="StockType" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:TemplateField HeaderText="SalesPrice" SortExpression="SalesPrice">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("SalesPrice") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="txtPrice" runat="server" Text='<%# Bind("SalesPrice") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fee" SortExpression="Fee">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Fee") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:textbox ID="txtFee" runat="server" Text='<%# Bind("Fee") %>'></asp:textbox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MIS333K_msbck614ConnectionString %>" SelectCommand="SELECT * FROM [tblStocks]"></asp:SqlDataSource>
        <br />
        <br />



        &#39;should have&nbsp; gridview with textboxes, talk with nicole in the morning about this</div>
</asp:Content>
