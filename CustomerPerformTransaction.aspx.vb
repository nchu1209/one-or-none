﻿Public Class CustomerPerformTransaction
    Inherits System.Web.UI.Page
    Dim DBAccounts As New ClassDBAccounts
    Dim DB As New ClassDBCustomer
    Dim DBTransactions As New ClassDBTransactions
    Dim Format As New ClassFormat
    Dim mCustomerID As Integer
    Dim Valid As New ClassValidate

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("CustomerNumber") Is Nothing Then
            Response.Redirect("CustomerLogin.aspx")
        End If

        DBAccounts.GetAccountByCustomerNumber(Session("CustomerNumber").ToString)
        ''get the record id from the select
        mCustomerID = CInt(Session("CustomerNumber"))

        If IsPostBack = False Then
            SetFormNormal()
        End If
        txtDepositDate.ReadOnly = True
        txtTransferDate.ReadOnly = True
        txtWithdrawalDate.ReadOnly = True
    End Sub

    Private Sub SetFormNormal()
        WithdrawalPanel.Visible = False
        DepositPanel.Visible = False
        TransferPanel.Visible = False
    End Sub

    Public Function ValidateAmount(strIn As String)
        If IsNumeric(strIn) = False Then
            Return False
        ElseIf CDec(strIn) <= 0 Then
            Return False
        End If
        Return True
    End Function

    Public Sub GetTransactionNumber()
        DBTransactions.GetMaxTransactionNumber()
        If DBTransactions.TransactionsDataset.Tables("tblTransactions").Rows.Count = 0 Then
            Session("TransactionNumber") = 1
        Else
            Session("TransactionNumber") = CInt(DBTransactions.TransactionsDataset.Tables("tblTransactions").Rows(0).Item("MaxTransactionNumber")) + 1
        End If
    End Sub

    Protected Sub ddlTransactions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlTransactions.SelectedIndexChanged
        SetFormNormal()
        If ddlTransactions.SelectedValue = "Withdrawal" Then
            WithdrawalPanel.Visible = True
        End If

        If ddlTransactions.SelectedValue = "Deposit" Then
            DepositPanel.Visible = True
            'fill the ddl
            'did not do in separate function since we have 4 different ddls on this page (gah pannels)
            DBAccounts.GetAccountByCustomerNumberTransfer(Session("CustomerNumber").ToString)
            ddlDeposit.DataSource = DBAccounts.AccountsDataset5
            ddlDeposit.DataTextField = "AccountName"
            ddlDeposit.DataValueField = "AccountNumber"
            ddlDeposit.DataBind()
        End If

        If ddlTransactions.SelectedValue = "Transfer" Then
            TransferPanel.Visible = True
        End If
    End Sub

    Protected Sub WithdrawalCalendar_SelectionChanged(sender As Object, e As EventArgs) Handles WithdrawalCalendar.SelectionChanged
        txtWithdrawalDate.Text = WithdrawalCalendar.SelectedDate
    End Sub

    Protected Sub DepositCalendar_SelectionChanged(sender As Object, e As EventArgs) Handles DepositCalendar.SelectionChanged
        txtDepositDate.Text = DepositCalendar.SelectedDate
    End Sub

    Protected Sub TransferCalendar_SelectionChanged(sender As Object, e As EventArgs) Handles TransferCalendar.SelectionChanged
        txtTransferDate.Text = TransferCalendar.SelectedDate
    End Sub

    Protected Sub btnDeposit_Click(sender As Object, e As EventArgs) Handles btnDeposit.Click
        If ValidateAmount(txtDepositAmount.Text) = False Then
            lblErrorDeposit.Text = "Please enter a positive, numeric amount"
            Exit Sub
        End If

        'add a validation here to make sure selected date is greater or equal to system date

        'update the balance
        Dim decBalance As Decimal
        DBAccounts.GetBalanceByAccountNumber(ddlDeposit.SelectedValue.ToString)
        decBalance = CDec(DBAccounts.AccountsDataset6.Tables("tblAccounts").Rows(0).Item("Balance"))
        decBalance += CDec(txtDepositAmount.Text)
        DBAccounts.UpdateBalance(CInt(ddlDeposit.SelectedValue), decBalance)
        lblErrorDeposit.Text = "Deposit Confirmed"

        Dim strDepositMessage As String
        strDepositMessage = "Deposited " & txtDepositAmount.Text & " to account " & ddlDeposit.SelectedValue.ToString & " on " & txtDepositDate.Text
        GetTransactionNumber()
        'update the transactions table
        DBTransactions.AddTransaction(CInt(Session("TransactionNumber")), CInt(ddlDeposit.SelectedValue), "Deposit", txtDepositDate.Text, CDec(txtDepositAmount.Text), strDepositMessage, decBalance)
    End Sub
End Class