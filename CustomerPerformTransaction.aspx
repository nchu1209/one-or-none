<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/CustomerMaster.Master" CodeBehind="CustomerPerformTransaction.aspx.vb" Inherits="Group3_LonghornBank.CustomerPerformTransaction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="ContentStyle.css" rel="stylesheet" type="text/css" />
     <div id ="title">
        Perfom Transaction
         <br />
         <br />
    </div>
    <div id="center">
        <asp:DropDownList ID="ddlTransactions" runat="server"></asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="... to say what is selected from drop down"></asp:Label>
        <br />
       

        <%-- because the money comes from an outside source, any amount is allowed --%>
         <asp:Panel ID="Deposit" runat="server" Visible =" false">
         <div id ="label">
             <asp:Label ID="Label1" runat="server" Text="Deposit Amount: "></asp:Label>
             <br />
             <br />

             <asp:Label ID="Label2" runat="server" Text="Deposit Into: "></asp:Label>
          </div>
        
             <div id="textbox">
                 <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                 <br />
             <br />
                 <asp:DropDownList ID="DropDownList1" runat="server">
             </asp:DropDownList>
             </div>
             
             

        
             

        
        </asp:Panel>
    </div>
    

</asp:Content>
