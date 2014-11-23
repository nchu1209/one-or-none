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
        <br />
        <asp:GridView ID="gvMyPayees" runat="server" AutoGenerateColumns="False" DataKeyNames="PayeeID" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="PayeeID" HeaderText="PayeeID" ReadOnly="True" SortExpression="PayeeID" />
                <asp:TemplateField HeaderText="PayeeName" SortExpression="PayeeName">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("PayeeName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:hyperlink ID="lnkName" runat="server" NavigateUrl='<%# "CustomerAddPayee.aspx"%>' Text='<%# Bind("PayeeName") %>'></asp:hyperlink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="PayeeType" HeaderText="PayeeType" SortExpression="PayeeType" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MIS333K_msbck614ConnectionString2 %>" SelectCommand="usp_innerjoin_customerspayees_payees_by_customernumber" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:SessionParameter Name="customernumber" SessionField="CustomerNumber" />
            </SelectParameters>
        </asp:SqlDataSource>
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
            From Account:<br />

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
            <asp:DropDownList ID="ddlAccount" runat="server">
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
