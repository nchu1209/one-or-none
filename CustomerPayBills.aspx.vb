Public Class CustomerPayBills
    Inherits System.Web.UI.Page

    Dim dbpay As New ClassDBPayee
    Dim valid As New ClassValidate
    Dim dbact As New ClassDBAccounts
    Dim dbdate As New ClassDBDate

    Dim mdecTotalAmount As Decimal

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("CustomerFirstName") Is Nothing Then
            Response.Redirect("CustomerLogin.aspx")
        End If

        dbpay.GetCustomerPayees(Session("CustomerNumber"))

        ddlPayee.DataSource = dbpay.PayeeDataset.Tables("tblPayees")
        ddlPayee.DataTextField = "PayeeName"
        ddlPayee.DataValueField = "PayeeID"
        ddlPayee.DataBind()

        dbact.GetCheckingandSavingsByCustomerNumber(Session("CustomerNumber"))
        ddlAccount.DataSource = dbact.AccountsDataset.Tables("tblAccounts")
        ddlAccount.DataTextField = "Details"
        ddlAccount.DataValueField = "AccountNumber"
        ddlAccount.DataBind()


        If IsPostBack = False Then
            mdecTotalAmount = 0
        End If

        lblMessageTotal.Text = ""
        lblMessageFee.Text = ""
        lblMessageSuccess.Text = ""

        btnConfirm.Visible = False

    End Sub

    Protected Sub txtPay_Click(sender As Object, e As EventArgs) Handles btnPay.Click
        'validate selected account balance >= 0

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

        'validate date (today or later)
        dbdate.GetDate()

        'if today, post immediately
        For i = 0 To gvMyPayees.Rows.Count - 1
            Dim t As TextBox = DirectCast(gvMyPayees.Rows(i).Cells(4).FindControl("txtAmount"), TextBox)
            If t.Text <> "" Then
                mdecTotalAmount += CDec(t.Text)
            End If
        Next
        lblMessageTotal.Text = "Total Amount = " & mdecTotalAmount.ToString("c2")

        'if in future, schedule as pending payment

    End Sub
End Class