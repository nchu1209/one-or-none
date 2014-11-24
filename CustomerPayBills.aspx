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
        <div id ="subtitle">Your Payees - Make a Payment</div>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Select Account:"></asp:Label>
&nbsp;
        <asp:DropDownList ID="ddlAccount" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        <br />
        <div id ="gridviewleft">
        <asp:GridView ID="gvMyPayees" runat="server" AutoGenerateColumns="False" DataKeyNames="PayeeID" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="PayeeID" HeaderText="PayeeID" ReadOnly="True" SortExpression="PayeeID" Visible="False" />
                <asp:TemplateField HeaderText="PayeeName" SortExpression="PayeeName">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("PayeeName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:hyperlink ID="lnkName" runat="server" NavigateUrl='<%# "CustomerUpdatePayee.aspx?ID=" & Eval("PayeeID")%>' Text='<%# Bind("PayeeName") %>'></asp:hyperlink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="PayeeType" HeaderText="PayeeType" SortExpression="PayeeType" />
                <asp:TemplateField HeaderText="Payment Amount">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Payment Date">
                  <EditItemTemplate>
                        <asp:calendar ID="calDate" runat="server"></asp:calendar>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:calendar ID="calDate" runat="server"></asp:calendar>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MIS333K_msbck614ConnectionString2 %>" SelectCommand="usp_innerjoin_customerspayees_payees_by_customernumber" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:SessionParameter Name="customernumber" SessionField="CustomerNumber" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        </div>
        <div id ="gridviewright">
            <asp:Button ID="btnPay" runat="server" Text="Pay" />
        <br />
        <br />
            <asp:Label ID="lblMessageTotal" runat="server" Text="[]"></asp:Label>
            <br />
        <asp:Label ID="lblMessageFee" runat="server" Text="[]"></asp:Label>
        <br />
        <br />
            <asp:Button ID="btnConfirm" runat="server" Text="Confirm" />
        <br />
        <br />
        <asp:Label ID="lblMessageSuccess" runat="server" Text="[]"></asp:Label>
        <br />
        </div>
    </div>
    <div id ="righthalf">
        <div id ="subtitle">View eBills</div>
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
            <br />
            <br />
            <asp:Calendar ID="calTest" runat="server"></asp:Calendar>
            <br />
            <asp:Button ID="btnTest" runat="server" Text="Test" />
            <br />
            <br />
            <asp:Label ID="lblTest" runat="server" Text="_"></asp:Label>
            <br />
            <br />
        </div>
        <br />
      

    </div>
</asp:Content>
