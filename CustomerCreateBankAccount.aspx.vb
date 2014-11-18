Public Class CustomerCreateBankAccount
    Inherits System.Web.UI.Page

    Dim DB As New ClassDBAccounts


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub ddlBankAccounts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlBankAccounts.SelectedIndexChanged
        DB.GetAllAccounts()
        DB.GetMaxAccountNumber()

        If DB.AccountsDataset.Tables("tblAccounts").Rows(0).Item("MaxAccountNumber") Is Nothing Then
            Session("AccountNumber") = 1000000000
        Else
            Session("AccountNumber") = DB.AccountsDataset.Tables("tblAccounts").Rows(0).Item("MaxAccountNumber")
        End If

        If ddlBankAccounts.SelectedIndex = 1 Then
            txtAccountName.Text = "Longhorn Checking"
        End If

        If ddlBankAccounts.SelectedIndex = 2 Then
            txtAccountName.Text = "Longhorn Savings"
        End If
    End Sub
End Class