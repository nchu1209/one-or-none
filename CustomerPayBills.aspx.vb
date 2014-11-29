Public Class CustomerPayBills
    Inherits System.Web.UI.Page

    Dim dbpay As New ClassDBPayee
    Dim valid As New ClassValidate
    Dim dbact As New ClassDBAccounts
    Dim dbdate As New ClassDBDate
    Dim dbtrans As New ClassDBTransactions
    Dim dbpending As New ClassDBPending
    Dim dbbill As New ClassDBBill

    Dim mdecTotalWithdrawal As Decimal
    Dim mdecBalance As Decimal

    Const OVERDRAFT_MAXIMUM As Decimal = 50D

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("CustomerFirstName") Is Nothing Then
            Response.Redirect("CustomerLogin.aspx")
        End If

        If IsPostBack = False Then
            dbpay.GetCustomerPayees(Session("CustomerNumber"))

            dbact.GetCheckingandSavingsByCustomerNumber(Session("CustomerNumber"))
            ddlAccount.DataSource = dbact.AccountsDataset.Tables("tblAccounts")
            ddlAccount.DataTextField = "Details"
            ddlAccount.DataValueField = "AccountNumber"
            ddlAccount.DataBind()

            btnConfirm.Visible = False
            btnAbort.Visible = False

            dbbill.GetCustomerBills(Session("CustomerNumber"))
            If dbbill.BillDataset.Tables("tblBill").Rows.Count <> 0 Then
                For i = 0 To gvMyPayees.Rows.Count - 1
                    For k = 0 To dbbill.BillDataset.Tables("tblBill").Rows.Count - 1
                        Dim x As Label = DirectCast(gvMyPayees.Rows(i).Cells(1).FindControl("lblPayeeID"), Label)
                        If CInt(x.Text) = dbbill.BillDataset.Tables("tblBill").Rows(k).Item("PayeeID") Then
                            Dim b As ImageButton = DirectCast(gvMyPayees.Rows(i).Cells(3).FindControl("btnBill"), ImageButton)
                            Dim a As Label = DirectCast(gvMyPayees.Rows(i).Cells(3).FindControl("lblBillAmount"), Label)
                            Dim d As Label = DirectCast(gvMyPayees.Rows(i).Cells(4).FindControl("lblDueDate"), Label)
                            'set notification
                            b.ImageUrl = "~/eBill.jpg"
                            b.Enabled = True
                            b.CommandName = "GoToBill"
                            'highlight payee
                            gvMyPayees.Rows(i).BackColor = Drawing.Color.LightGray
                            'populate bill due date and amount
                            Dim decBill As Decimal
                            decBill = CDec(dbbill.BillDataset.Tables("tblBill").Rows(k).Item("BillAmount"))
                            a.Text = decBill.ToString("c2")
                            Dim datBill As Date
                            datBill = CDate(dbbill.BillDataset.Tables("tblBill").Rows(k).Item("DueDate")).Date
                            d.Text = datBill.ToString
                        End If
                    Next
                Next
            End If
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
            Dim t As TextBox = DirectCast(gvMyPayees.Rows(i).Cells(4).FindControl("txtAmount"), TextBox)
            If t.Text <> "" Then
                If valid.CheckDecimal(t.Text) = -1 Then
                    lblMessageTotal.Text = "Please enter valid payment amounts."
                    Exit Sub
                End If
            End If
        Next

        'validate date fields
        For i = 0 To gvMyPayees.Rows.Count - 1
            Dim t As TextBox = DirectCast(gvMyPayees.Rows(i).Cells(4).FindControl("txtAmount"), TextBox)
            Dim c As Calendar = DirectCast(gvMyPayees.Rows(i).Cells(5).FindControl("calDate"), Calendar)
            If t.Text <> "" Then
                If dbdate.CheckSelectedDate(c.SelectedDate) = -1 Then
                    lblMessageTotal.Text = "Please do not enter a date prior to today's date."
                    Exit Sub
                End If
            End If
        Next

        'find the total withdrawal amount wooooo
        For i = 0 To gvMyPayees.Rows.Count - 1
            Dim t As TextBox = DirectCast(gvMyPayees.Rows(i).Cells(4).FindControl("txtAmount"), TextBox)
            Dim c As Calendar = DirectCast(gvMyPayees.Rows(i).Cells(5).FindControl("calDate"), Calendar)

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

    Protected Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        dbact.GetBalanceByAccountNumber(ddlAccount.SelectedValue.ToString)
        mdecBalance = CDec(dbact.AccountsDataset6.Tables("tblAccounts").Rows(0).Item("Balance"))

        'pay bills - now and pending
        For i = 0 To gvMyPayees.Rows.Count - 1
            Dim t As TextBox = DirectCast(gvMyPayees.Rows(i).Cells(4).FindControl("txtAmount"), TextBox)
            Dim c As Calendar = DirectCast(gvMyPayees.Rows(i).Cells(5).FindControl("calDate"), Calendar)
            Dim n As HyperLink = DirectCast(gvMyPayees.Rows(i).Cells(2).FindControl("lnkName"), HyperLink)

            If dbdate.CheckSelectedDate(c.SelectedDate) = 0 And t.Text <> "" Then
                'today
                mdecBalance = mdecBalance - CDec(t.Text)
                dbact.UpdateBalance(CInt(ddlAccount.SelectedValue), mdecBalance)

                Dim strPaymentMessage As String
                strPaymentMessage = "Sent payment of " & t.Text & " to " & n.Text & " from account " & ddlAccount.SelectedValue.ToString & " on " & c.SelectedDate.ToString
                GetTransactionNumber()
                'update the transactions table
                dbtrans.AddTransaction(CInt(Session("TransactionNumber")), CInt(ddlAccount.SelectedValue), "Payment", c.SelectedDate, CDec(t.Text), strPaymentMessage, mdecBalance, "")
            End If

            If dbdate.CheckSelectedDate(c.SelectedDate) = 1 And t.Text <> "" Then
                'schedule payments
                Dim strPendingMessage As String
                strPendingMessage = "Send payment of " & t.Text & " to " & n.Text & " from account " & ddlAccount.SelectedValue.ToString & " on " & c.SelectedDate.ToString
                GetTransactionNumber()
                'update pending transactions table
                dbpending.AddTransaction(CInt(Session("TransactionNumber")), CInt(ddlAccount.SelectedValue), "Payment", c.SelectedDate, CDec(t.Text), strPendingMessage, "")
            End If
        Next

        lblMessageSuccess.Text = "Payments successfully sent and/or scheduled."
        btnConfirm.Visible = False
        btnAbort.Visible = False

    End Sub

    Protected Sub btnAbort_Click(sender As Object, e As EventArgs) Handles btnAbort.Click
        btnConfirm.Visible = False
        btnAbort.Visible = False
    End Sub

    Protected Sub gvMyPayees_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        If (e.CommandName = "GoToBill") Then
            ' Retrieve the row index stored in the CommandArgument property.
            Dim intRow As Integer = Convert.ToInt32(e.CommandArgument)

            ' Retrieve the row that contains the button 
            ' from the Rows collection.
            Dim row As GridViewRow = gvMyPayees.Rows(intRow)

            '' Add code here to add the item to the shopping cart.
            dbbill.GetCustomerBills(Session("CustomerNumber"))
            Response.Redirect("CustomerBillDetail.aspx?ID=" & dbbill.BillDataset.Tables("tblBill").Rows(intRow).Item("BillID"))

        End If
    End Sub

End Class