﻿Public Class ManagerSetDate
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
        db.GetDate()

        Dim intTransactionNumber As Integer
        Dim intAccountNumber As Integer
        Dim strTransactionType As String
        Dim strDate As String
        Dim decTransactionAmount As Decimal
        Dim strDescription As String
        Dim decAccountBalance As Decimal
        Dim strIRA As String

        dbpending.GetAllPendingTransactions()
        For i = 0 To dbpending.PendingDataset2.Tables("tblPending").Rows.Count - 1
            If dbpending.PendingDataset2.Tables("tblPending").Rows(i).Item("Date") <= db.DateDataset.Tables("tblSystemDate").Rows(0).Item("Date") Then
                'send information to transaction table and update balance
                intTransactionNumber = CInt(dbpending.PendingDataset2.Tables("tblPending").Rows(i).Item("TransactionNumber"))
                intAccountNumber = CInt(dbpending.PendingDataset2.Tables("tblPending").Rows(i).Item("AccountNumber"))
                strTransactionType = dbpending.PendingDataset2.Tables("tblPending").Rows(i).Item("TransactionType").ToString
                strDate = dbpending.PendingDataset2.Tables("tblPending").Rows(i).Item("Date").ToString
                decTransactionAmount = CDec(dbpending.PendingDataset2.Tables("tblPending").Rows(i).Item("TransactionAmount"))
                strDescription = dbpending.PendingDataset2.Tables("tblPending").Rows(i).Item("Description").ToString
                strIRA = dbpending.PendingDataset2.Tables("tblPending").Rows(i).Item("IRA").ToString

                dbaccounts.GetBalanceByAccountNumber(intAccountNumber.ToString)

                If strTransactionType = "Deposit" Then
                    decAccountBalance = CDec(dbaccounts.AccountsDataset6.Tables("tblAccounts").Rows(0).Item("Balance")) + decTransactionAmount
                End If

                If strTransactionType = "Withdrawal" Or strTransactionType = "Payment" Then
                    decAccountBalance = CDec(dbaccounts.AccountsDataset6.Tables("tblAccounts").Rows(0).Item("Balance")) - decTransactionAmount
                End If

                If strTransactionType = "Transfer To" Then
                    decAccountBalance = CDec(dbaccounts.AccountsDataset6.Tables("tblAccounts").Rows(0).Item("Balance")) + decTransactionAmount
                End If

                If strTransactionType = "Transfer From" Then
                    decAccountBalance = CDec(dbaccounts.AccountsDataset6.Tables("tblAccounts").Rows(0).Item("Balance")) - decTransactionAmount
                End If

                If strIRA = "True" And (strTransactionType = "Deposit" Or strTransactionType = "Transfer To") Then
                    dbaccounts.GetIRATotalDepositByAccountNumber(intAccountNumber)
                    Dim decIRATotal As Decimal
                    decIRATotal = CDec(dbaccounts.AccountsDataset8.Tables("tblAccounts").Rows(0).Item("IRATotalDeposit"))
                    dbaccounts.UpdateIRATotalDeposit(intAccountNumber, decIRATotal + decTransactionAmount)
                End If

                If strTransactionType = "Transfer To" Then
                    strTransactionType = "Transfer"
                End If

                If strTransactionType = "Transfer From" Then
                    strTransactionType = "Transfer"
                End If

                'add transaction
                'update balance
                dbtransaction.AddTransaction(intTransactionNumber, intAccountNumber, strTransactionType, strDate, decTransactionAmount, strDescription, decAccountBalance, "NULL", strIRA)
                dbaccounts.UpdateBalance(intAccountNumber, decAccountBalance)

                'delete row from tblPending
                dbpending.DeleteTransaction(intTransactionNumber)
            End If

        Next
        lblError.Text = "Date successfully changed"
        Response.AddHeader("Refresh", "2; URL= ManagerHome.aspx")
    End Sub
End Class