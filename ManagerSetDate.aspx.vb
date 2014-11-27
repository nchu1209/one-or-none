Public Class ManagerSetDate
    Inherits System.Web.UI.Page

    Dim db As New ClassDBDate
    Dim dbpending As New ClassDBPending
    Dim dbtransaction As New ClassDBTransactions
    Dim dbaccounts As New ClassDBAccounts
    Dim mstrDate As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub calSetDate_SelectionChanged(sender As Object, e As EventArgs) Handles calSetDate.SelectionChanged
        
        mstrDate = calSetDate.SelectedDate.Year & "-" & calSetDate.SelectedDate.Month & "-" & calSetDate.SelectedDate.Day

        txtDate.Text = mstrDate
    End Sub

    Protected Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        db.SetDate(txtDate.Text)

        dbpending.GetAllPendingTransactions()
        db.GetDate()

        Dim intTransactionNumber As Integer
        Dim intAccountNumber As Integer
        Dim strTransactionType As String
        Dim strDate As String
        Dim decTransactionAmount As Decimal
        Dim strDescription As String
        Dim decAccountBalance As Decimal

        For i = 0 To dbpending.PendingDataset2.Tables("tblPending").Rows.Count - 1
            If dbpending.PendingDataset2.Tables("tblPending").Rows(i).Item("Date") <= db.DateDataset.Tables("tblSystemDate").Rows(0).Item("Date") Then
                'send information to transaction table and update balance
                intTransactionNumber = CInt(dbpending.PendingDataset2.Tables("tblPending").Rows(i).Item("TransactionNumber"))
                intAccountNumber = CInt(dbpending.PendingDataset2.Tables("tblPending").Rows(i).Item("AccountNumber"))
                strTransactionType = dbpending.PendingDataset2.Tables("tblPending").Rows(i).Item("TransactionType").ToString
                strDate = dbpending.PendingDataset2.Tables("tblPending").Rows(i).Item("Date").ToString
                decTransactionAmount = CDec(dbpending.PendingDataset2.Tables("tblPending").Rows(i).Item("TransactionAmount"))
                strDescription = dbpending.PendingDataset2.Tables("tblPending").Rows(i).Item("Description").ToString

                dbaccounts.GetBalanceByAccountNumber(intAccountNumber.ToString)

                If strTransactionType = "Deposit" Then
                    decAccountBalance = CDec(dbaccounts.AccountsDataset6.Tables("tblAccounts").Rows(0).Item("Balance")) + decTransactionAmount
                End If

                If strTransactionType = "Withdrawal" Or strTransactionType = "Payment" Then
                    decAccountBalance = CDec(dbaccounts.AccountsDataset6.Tables("tblAccounts").Rows(0).Item("Balance")) - decTransactionAmount
                End If

                'not sure how to handle transfers???

                dbtransaction.AddTransaction(intTransactionNumber, intAccountNumber, strTransactionType, strDate, decTransactionAmount, strDescription, decAccountBalance)

                'delete row from tblPending
                dbpending.DeleteTransaction(intTransactionNumber)
            End If

        Next

    End Sub
End Class