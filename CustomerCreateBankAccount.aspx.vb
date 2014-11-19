﻿Public Class CustomerCreateBankAccount
    Inherits System.Web.UI.Page

    Dim DB As New ClassDBAccounts
    Dim Valid As New ClassValidate

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub ddlBankAccounts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlBankAccounts.SelectedIndexChanged
        'reset error label
        lblError.Text = ""

        'find the maximum existing account number in the database, and add one to create the new account's number
        DB.GetMaxAccountNumber()
        If IsDBNull(DB.AccountsDataset.Tables("tblAccounts").Rows(0).Item("MaxAccountNumber")) = True Then
            Session("AccountNumber") = 999999999
        Else
            Session("AccountNumber") = DB.AccountsDataset.Tables("tblAccounts").Rows(0).Item("MaxAccountNumber")
        End If

        txtAccountNumber.Text = (CInt(Session("AccountNumber")) + 1).ToString

        'set the name of the bank account; use defaults for checking and savings; user may change if desired
        'set account type

        If ddlBankAccounts.SelectedIndex = 1 Then
            txtAccountName.Text = "Longhorn Checking"
            Session("AccountType") = "Checking"
        End If

        If ddlBankAccounts.SelectedIndex = 2 Then
            txtAccountName.Text = "Longhorn Savings"
            Session("AccountType") = "Savings"
        End If

        If ddlBankAccounts.SelectedIndex = 3 Then
            DB.GetByCustomerNumberIRA(Session("CustomerNumber")
            txtAccountName.Text = ""
            Session("AccountType") = "IRA"
        End If

        If ddlBankAccounts.SelectedIndex = 4 Then
            txtAccountName.Text = ""
            Session("AccountType") = "Stock"
        End If
    End Sub

    Protected Sub btnSaveProfile_Click(sender As Object, e As EventArgs) Handles btnApply.Click
        If Not IsValid Then
            Exit Sub
        End If

        'make sure deposit is numeric
        If Valid.CheckDigits(txtInitialDeposit.Text) = False Then
            lblError.Text = "Please enter a valid initial deposit"
            Exit Sub
        End If

        'make sure deposit is not negative
        If CInt(txtInitialDeposit.Text) < 0 Then
            lblError.Text = "Please enter an initial deposit of $0 or more"
            Exit Sub
        End If

        'if the account is an IRA, they cannot deposit more than 5k
        'but they are automatically stopped by the initial deposit validation below
        'but we need to make sure the manager cannot approve them -- they cannot enter that much regardless, so perhaps its better to stop them now
        If Session("AccountType").ToString = "IRA" Then
            If CInt(txtInitialDeposit.Text) > 5000 Then
                lblError.Text = "You cannot enter more than $5000 into an IRA account per year. Please select a lower initial deposit"
                Exit Sub
            End If
        End If

        ''right now this is here to trigger a label for the manager that the deposit needs to be verified -- once manager approves, 
        'set session to true, go into database and change account to active and approved deposit to true
        Session("Active") = "True"
        Session("ManagerApprovedDeposit") = "True"
        If CInt(txtInitialDeposit.Text) >= 5000 Then
            Session("Active") = "False"
            Session("ManagerApprovedDeposit") = "False"
        End If

        'if the account is a stock account, they automatically need manager approval
        If Session("AccountType").ToString = "Stock" Then
            Session("Active") = "False"
        End If

        'to add the account, we need: 
        'CustomerID ?!?! --> session variable from log on?
        'account number, account name, account type, active, manager approved deposit, initial, balance
        'automatically active or should we wait for the manager approved deposit? 
        'is the manager approved deposit false until the manager approves it? if the deposit is under 5k, should it automatically be true?
        DB.AddAccount(CInt(Session("CustomerNumber")), CInt(txtAccountNumber.Text), txtAccountName.Text, Session("AccountType").ToString, Session("Active").ToString, Session("ManagerApprovedDeposit").ToString, CInt(txtInitialDeposit.Text), CInt(txtInitialDeposit.Text))

        'clear form once application is submitted and show message to customer. or redirect after lag????
        lblError.Text = "Application Submitted"
        txtAccountName.Text = ""
        txtAccountNumber.Text = ""
        txtInitialDeposit.Text = ""
        ddlBankAccounts.SelectedIndex = 0
    End Sub

    Protected Sub btnCancelProfile_Click(sender As Object, e As EventArgs) Handles btnCancelProfile.Click
        Response.Redirect("CustomerHome.aspx")
    End Sub
End Class