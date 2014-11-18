Public Class CustomerCreateBankAccount
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub ddlBankAccounts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlBankAccounts.SelectedIndexChanged
        If ddlBankAccounts.SelectedIndex = 1 Then
            txtAccountName.Text = "Longhorn Checking"
        End If

        If ddlBankAccounts.SelectedIndex = 2 Then
            txtAccountName.Text = "Longhorn Savings"
        End If
    End Sub
End Class