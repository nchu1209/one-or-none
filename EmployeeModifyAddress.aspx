<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/EmployeeMaster.Master" CodeBehind="EmployeeModifyAddress.aspx.vb" Inherits="KProject.EmployeeModifyAddress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="ContentStyle.css" rel="stylesheet" type="text/css" />
    <div id ="title">
        Modify Employee Address
        <br />
        <br />
    </div>



      <div id="employeeModifyAddress" style="text-align: center">

            <br />
            <br />
            Address<br />
            <asp:TextBox ID="txtAddress" runat="server" Width="168px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAddress" ErrorMessage="Need Address">*</asp:RequiredFieldValidator>
            <br />
            Zip Code<br />
            <asp:TextBox ID="txtZipcode" runat="server" Width="89px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ClientIDMode="Static" ControlToValidate="txtZipcode" ErrorMessage="Zipcode is Required">*</asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Button ID="btnModifyAddress" runat="server" Text="Modify Address" />
            <br />
            <br />
            <br />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            <asp:Label ID="lblError" runat="server" Text=""></asp:Label>

        </div>


</asp:Content>
