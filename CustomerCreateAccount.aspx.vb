Option Strict On

Public Class CustomerCreateAccount

    Inherits System.Web.UI.Page

    Dim DB As New ClassDBCustomer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnCancelProfile_Click(sender As Object, e As EventArgs) Handles btnCancelProfile.Click
        Response.Redirect("CustomerLogin.aspx")
    End Sub

    Protected Sub btnSaveProfile_Click(sender As Object, e As EventArgs) Handles btnSaveProfile.Click
        Dim intCustomerNumber As Integer

        DB.CustomerNumber()

        intCustomerNumber = CInt(DB.CustDataset2.Tables("tblCustomers").Rows(0).Item("CustomerNumber2")) + 1




        If Not IsValid Then
            Exit Sub
        End If

        DB.AddCustomer(intCustomerNumber, txtLastName.Text, txtFirstName.Text, txtInitial.Text, txtPassword.Text, txtAddress.Text, txtZip.Text, txtEmail.Text, txtPhone.Text, txtDOB.Text)

    End Sub
End Class