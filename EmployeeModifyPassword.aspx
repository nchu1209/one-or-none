<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/EmployeeMaster.Master" CodeBehind="EmployeeModifyPassword.aspx.vb" Inherits="KProject.EmployeeModifyPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id ="textbox" class="text-center">
         Old Password:<asp:TextBox ID="txtOld" runat="server" Width="135px"></asp:TextBox>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOld" ErrorMessage="You must enter your old password to update.">*</asp:RequiredFieldValidator>
         <br />
        <br />
               
         New Password:<asp:TextBox ID="txtNew" runat="server" Width="135px"></asp:TextBox>
        
         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNew" ErrorMessage="To update, you must enter a new password.">*</asp:RequiredFieldValidator>
        
        <br />
        
        <br />
        <asp:Button ID="btnConfirmPassword" runat="server" Text="Confirm" />

         <br />
         <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
         <br />
          <asp:Label ID="lblErrorPassword" runat="server"></asp:Label>
         </div>
</asp:Content>
