Public Class CustomerBillDetail
    Inherits System.Web.UI.Page

    Dim dbbill As New ClassDBBill
    Dim dbaccount As New ClassDBAccounts
    Dim dbDate As New ClassDBDate
    Dim dbtrans As New ClassDBTransactions
    Dim dbpending As New ClassDBPending
    Dim format As New ClassFormat
    Dim valid As New ClassValidate

    Dim mdecBalance As Decimal
    Dim mdecBillAmount As Decimal
    Dim mdecPayment As Decimal

    Const OVERDRAFT_MAXIMUM As Decimal = 50D
    Const OVERDRAFT_FEE As Decimal = 30D

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("CustomerNumber") Is Nothing Then
            Response.Redirect("CustomerLogin.aspx")
        End If

        If Request.QueryString("ID") Is Nothing Then
            Response.Redirect("CustomerPayBills.aspx")
        End If

        lblBillID.Text = Request.QueryString("ID")
        dbbill.GetBillDetails(Request.QueryString("ID"))

        If IsPostBack = False Then
            FillTextboxes()

            dbaccount.GetCheckingandSavingsByCustomerNumber(Session("CustomerNumber"))
            ddlAccount.DataSource = dbaccount.AccountsDataset.Tables("tblAccounts")
            ddlAccount.DataTextField = "Details"
            ddlAccount.DataValueField = "AccountNumber"
            ddlAccount.DataBind()

        End If
        
        btnConfirm.Visible = False
        btnAbort.Visible = False
        lblMessage.Text = ""
        lblMessageFee.Text = ""
    End Sub

    Private Sub FillTextboxes()
        Dim strPhone As String
        Dim decAmountPaid As Decimal
        Dim decAmountRemaining As Decimal
        txtCustomerName.Text = dbbill.BillDataset.Tables("tblBill").Rows(0).Item("CustomerName").ToString
        mdecBillAmount = CDec(dbbill.BillDataset.Tables("tblBill").Rows(0).Item("BillAmount"))
        txtBillAmount.Text = mdecBillAmount.ToString("c2")
        decAmountPaid = CDec(dbbill.BillDataset.Tables("tblBill").Rows(0).Item("AmountPaid"))
        txtAmountPaid.Text = decAmountPaid.ToString("c2")
        decAmountRemaining = CDec(dbbill.BillDataset.Tables("tblBill").Rows(0).Item("AmountRemaining"))
        txtAmountRemaining.Text = decAmountRemaining.ToString("c2")
        txtBillDate.Text = dbbill.BillDataset.Tables("tblBill").Rows(0).Item("BillDate").ToString
        txtDueDate.Text = dbbill.BillDataset.Tables("tblBill").Rows(0).Item("DueDate").ToString
        txtPayeeName.Text = dbbill.BillDataset.Tables("tblBill").Rows(0).Item("PayeeName").ToString
        txtType.Text = dbbill.BillDataset.Tables("tblBill").Rows(0).Item("PayeeType").ToString
        txtPayeeAddress.Text = dbbill.BillDataset.Tables("tblBill").Rows(0).Item("Address").ToString
        txtZip.Text = dbbill.BillDataset.Tables("tblBill").Rows(0).Item("ZipCode").ToString

        strPhone = dbbill.BillDataset.Tables("tblBill").Rows(0).Item("Phone").ToString
        txtPhone.Text = format.FormatPhone(strPhone)
    End Sub

    Protected Sub btnPay_Click(sender As Object, e As EventArgs) Handles btnPay.Click
        'validations
        'validate selected account balance >= 0
        dbaccount.GetBalanceByAccountNumber(ddlAccount.SelectedValue.ToString)
        mdecBalance = CDec(dbaccount.AccountsDataset6.Tables("tblAccounts").Rows(0).Item("Balance"))

        If mdecBalance < 0 Then
            lblMessage.Text = "Please select a checking or savings account with a positive balance."
            Exit Sub
        End If

        'validate textbox
        If Page.IsValid = False Then
            Exit Sub
        End If

        If valid.CheckDecimal(txtAmount.Text) = -1 Then
            lblMessage.Text = "Please enter a valid payment amount."
            Exit Sub
        End If

        mdecPayment = CDec(txtAmount.Text)
        mdecBillAmount = CDec(dbbill.BillDataset.Tables("tblBill").Rows(0).Item("BillAmount"))

        If mdecPayment > mdecBillAmount Then
            lblMessage.Text = "The payment amount you have entered exceeds the total bill amount."
            Exit Sub
        End If

        'validate date field
        If dbdate.CheckSelectedDate(calDate.SelectedDate) = -1 Then
            lblMessage.Text = "Please do not enter a date prior to today's date."
            Exit Sub
        End If

        'validate that total amount is less than max withdrawal (overdraft stuff)
        If mdecBalance + OVERDRAFT_MAXIMUM < mdecPayment Then
            lblMessage.Text = "Your payment total is " & mdecPayment.ToString("c2") & ", which exceeds your account balance by more than the maximum overdraft amount (" & OVERDRAFT_MAXIMUM.ToString("c2") & ")."
            Exit Sub
        End If

        'whee confirmation stuff
        lblMessage.Text = "By clicking 'Confirm' below, you agree to send a total of " & mdecPayment.ToString("c2") & " to " & dbbill.BillDataset.Tables("tblBill").Rows(0).Item("PayeeName").ToString & "."
        btnConfirm.Visible = True
        btnAbort.Visible = True

        'overdraft fee notice
        If mdecBalance < mdecPayment And dbDate.CheckSelectedDate(calDate.SelectedDate) = 0 Then
            lblMessageFee.Text = "Note: The payment amount entered exceeds your selected account's balance. You will be charged an overdraft fee of $30.00 in addition to your specified payment."
        End If

    End Sub

    Protected Sub btnAbort_Click(sender As Object, e As EventArgs) Handles btnAbort.Click
        txtAmount.Text = ""
        calDate.SelectedDate = Nothing
    End Sub

    Protected Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        dbaccount.GetBalanceByAccountNumber(ddlAccount.SelectedValue.ToString)
        mdecBalance = CDec(dbaccount.AccountsDataset6.Tables("tblAccounts").Rows(0).Item("Balance"))

        'pay bill or schedule payment
        If dbDate.CheckSelectedDate(calDate.SelectedDate) = 0 Then
            mdecBalance = mdecBalance - CDec(txtAmount.Text)
            dbaccount.UpdateBalance(CInt(ddlAccount.SelectedValue), mdecBalance)

            Dim strPaymentMessage As String
            strPaymentMessage = "Sent eBill payment of " & txtAmount.Text & " to " & txtPayeeName.Text & " from account " & ddlAccount.SelectedValue.ToString & " on " & calDate.SelectedDate.ToString
            GetTransactionNumber()
            'update the transactions table
            dbtrans.AddTransaction(CInt(Session("TransactionNumber")), CInt(ddlAccount.SelectedValue), "eBill Payment", calDate.SelectedDate, CDec(txtAmount.Text), strPaymentMessage, mdecBalance, lblBillID.Text, "False")
        End If

        If dbDate.CheckSelectedDate(calDate.SelectedDate) = 1 Then
            'schedule payments
            Dim strPendingMessage As String
            strPendingMessage = "Sent eBill payment of " & txtAmount.Text & " to " & txtPayeeName.Text & " from account " & ddlAccount.SelectedValue.ToString & " on " & calDate.SelectedDate.ToString
            GetTransactionNumber()
            'update pending transactions table
            dbpending.AddTransaction(CInt(Session("TransactionNumber")), CInt(ddlAccount.SelectedValue), "eBill Payment", calDate.SelectedDate, CDec(txtAmount.Text), strPendingMessage, lblBillID.Text, "False")
        End If

        'overdraft fee if necessary
        If mdecBalance < 0 Then
            dbDate.GetDate()
            Dim datDate As Date
            datDate = dbDate.DateDataset.Tables("tblSystemDate").Rows(0).Item("Date").ToString()

            mdecBalance = mdecBalance - OVERDRAFT_FEE
            dbaccount.UpdateBalance(CInt(ddlAccount.SelectedValue), mdecBalance)

            Dim strFeeMessage As String
            strFeeMessage = "Overdraft fee of " & OVERDRAFT_FEE.ToString & " charged to account " & ddlAccount.SelectedValue.ToString & " on " & datDate.ToString
            GetTransactionNumber()
            'update the transactions table "
            dbtrans.AddTransaction(CInt(Session("TransactionNumber")), CInt(ddlAccount.SelectedValue), "Fee", datDate, OVERDRAFT_FEE, strFeeMessage, mdecBalance, "NULL", "False")
        End If

        lblMessage.Text = "Payments successfully sent and/or scheduled."
        btnConfirm.Visible = False
        btnAbort.Visible = False

        FillTextboxes()

    End Sub

    Private Sub GetTransactionNumber()
        dbtrans.GetMaxTransactionNumber()
        If dbtrans.TransactionsDataset.Tables("tblTransactions").Rows.Count = 0 Then
            Session("TransactionNumber") = 1
        Else
            Session("TransactionNumber") = CInt(dbtrans.TransactionsDataset.Tables("tblTransactions").Rows(0).Item("MaxTransactionNumber")) + 1
        End If
    End Sub

End Class