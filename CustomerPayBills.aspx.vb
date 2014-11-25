Public Class CustomerPayBills
    Inherits System.Web.UI.Page

    Dim dbpay As New ClassDBPayee
    Dim valid As New ClassValidate
    Dim dbact As New ClassDBAccounts
    Dim dbdate As New ClassDBDate
    Dim dbtrans As New ClassDBTransactions

    'Dim mdecTotalToday As Decimal
    'Dim mdecTotalPending As Decimal

    Dim mdecTotalWithdrawal As Decimal
    Dim mdecBalance As Decimal

    Const OVERDRAFT_MAXIMUM As Decimal = 50D

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("CustomerFirstName") Is Nothing Then
            Response.Redirect("CustomerLogin.aspx")
        End If

        If IsPostBack = False Then
            dbpay.GetCustomerPayees(Session("CustomerNumber"))

            'ddlPayee.DataSource = dbpay.PayeeDataset.Tables("tblPayees")
            'ddlPayee.DataTextField = "PayeeName"
            'ddlPayee.DataValueField = "PayeeID"
            'ddlPayee.DataBind()

            dbact.GetCheckingandSavingsByCustomerNumber(Session("CustomerNumber"))
            ddlAccount.DataSource = dbact.AccountsDataset.Tables("tblAccounts")
            ddlAccount.DataTextField = "Details"
            ddlAccount.DataValueField = "AccountNumber"
            ddlAccount.DataBind()

            btnConfirm.Visible = False
            btnAbort.Visible = False
        End If

        lblMessageTotal.Text = ""
        lblMessageFee.Text = ""
        lblMessageSuccess.Text = ""
        
    End Sub

    Protected Sub txtPay_Click(sender As Object, e As EventArgs) Handles btnPay.Click

        'validate selected account balance >= 0
        dbact.GetBalanceByAccountNumber(ddlAccount.SelectedValue.ToString)
        mdecBalance = CDec(dbact.AccountsDataset6.Tables("tblAccounts").Rows(0).Item("Balance"))

        If mdecBalance < 0 Then
            lblMessageTotal.Text = "Please select a checking or savings account with a positive balance."
            Exit Sub
        End If

        'validate textbox fields
        For i = 0 To gvMyPayees.Rows.Count - 1
            Dim t As TextBox = DirectCast(gvMyPayees.Rows(i).Cells(3).FindControl("txtAmount"), TextBox)
            If t.Text <> "" Then
                If valid.CheckDecimal(t.Text) = -1 Then
                    lblMessageTotal.Text = "Please enter valid payment amounts."
                    Exit Sub
                End If
            End If
        Next

        'validate date fields
        For i = 0 To gvMyPayees.Rows.Count - 1
            Dim t As TextBox = DirectCast(gvMyPayees.Rows(i).Cells(3).FindControl("txtAmount"), TextBox)
            Dim c As Calendar = DirectCast(gvMyPayees.Rows(i).Cells(4).FindControl("calDate"), Calendar)
            If t.Text <> "" Then
                If dbdate.CheckSelectedDate(c.SelectedDate) = -1 Then
                    lblMessageTotal.Text = "Please do not enter a date prior to today's date."
                    Exit Sub
                End If
            End If
        Next

        'find the total withdrawal amount wooooo
        For i = 0 To gvMyPayees.Rows.Count - 1
            Dim t As TextBox = DirectCast(gvMyPayees.Rows(i).Cells(3).FindControl("txtAmount"), TextBox)
            Dim c As Calendar = DirectCast(gvMyPayees.Rows(i).Cells(4).FindControl("calDate"), Calendar)

            If t.Text <> "" Then
                mdecTotalWithdrawal += CDec(t.Text)
            End If

        Next

        'validate that total amount is less than max withdrawal (overdraft stuff)
        If mdecBalance + OVERDRAFT_MAXIMUM < mdecTotalWithdrawal Then
            lblMessageTotal.Text = "Your payment total is " & mdecTotalWithdrawal.ToString("c2") & ", which exceeds your account balance by more than the maximum overdraft amount (" & OVERDRAFT_MAXIMUM.ToString("c2") & ")."
            Exit Sub
        End If

        'whee confirmation stuff
        lblMessageTotal.Text = "By clicking 'Confirm' below, you agree to send a total of " & mdecTotalWithdrawal.ToString("c2") & " to the specified payees."
        btnConfirm.Visible = True
        btnAbort.Visible = True

        'overdraft fee notice
        If mdecBalance < mdecTotalWithdrawal Then
            lblMessageFee.Text = "Note: You will be charged an overdraft fee of $30.00 in addition to your specified payment(s)."
        End If

    End Sub

    Private Sub GetTransactionNumber()
        dbtrans.GetMaxTransactionNumber()
        If dbtrans.TransactionsDataset.Tables("tblTransactions").Rows.Count = 0 Then
            Session("TransactionNumber") = 1
        Else
            Session("TransactionNumber") = CInt(dbtrans.TransactionsDataset.Tables("tblTransactions").Rows(0).Item("MaxTransactionNumber")) + 1
        End If
    End Sub

    Protected Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click
        Dim n As HyperLink = DirectCast(gvMyPayees.Rows(0).Cells(1).FindControl("lnkName"), HyperLink)

        lblTest.Text = n.Text
    End Sub

    Protected Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        dbact.GetBalanceByAccountNumber(ddlAccount.SelectedValue.ToString)
        mdecBalance = CDec(dbact.AccountsDataset6.Tables("tblAccounts").Rows(0).Item("Balance"))

        'pay bills - now and pending
        For i = 0 To gvMyPayees.Rows.Count - 1
            Dim t As TextBox = DirectCast(gvMyPayees.Rows(i).Cells(3).FindControl("txtAmount"), TextBox)
            Dim c As Calendar = DirectCast(gvMyPayees.Rows(i).Cells(4).FindControl("calDate"), Calendar)
            Dim n As HyperLink = DirectCast(gvMyPayees.Rows(i).Cells(1).FindControl("lnkName"), HyperLink)

            If dbdate.CheckSelectedDate(c.SelectedDate) = 0 And t.Text <> "" Then
                'today
                mdecBalance = mdecBalance - CDec(t.Text)
                dbact.UpdateBalance(CInt(ddlAccount.SelectedValue), mdecBalance)

                Dim strPaymentMessage As String
                strPaymentMessage = "Sent payment of " & t.Text & " to " & n.Text & " from account " & ddlAccount.SelectedValue.ToString & " on " & c.SelectedDate.ToString
                GetTransactionNumber()
                'update the transactions table
                dbtrans.AddTransaction(CInt(Session("TransactionNumber")), CInt(ddlAccount.SelectedValue), "Payment", c.SelectedDate, CDec(t.Text), strPaymentMessage, mdecBalance)
            End If

            If dbdate.CheckSelectedDate(c.SelectedDate) = 1 And t.Text <> "" Then
                'schedule payments
            End If
        Next

        lblMessageSuccess.Text = "Payments successfully sent and/or scheduled."

    End Sub

    Protected Sub btnAbort_Click(sender As Object, e As EventArgs) Handles btnAbort.Click
        btnConfirm.Visible = False
        btnAbort.Visible = False
    End Sub
End Class