Public Class CustomerPayBills
    Inherits System.Web.UI.Page

    Dim dbpay As New ClassDBPayee
    Dim valid As New ClassValidate
    Dim dbact As New ClassDBAccounts
    Dim dbdate As New ClassDBDate

    Dim mdecTotalToday As Decimal
    Dim mdecTotalPending As Decimal

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("CustomerFirstName") Is Nothing Then
            Response.Redirect("CustomerLogin.aspx")
        End If

        If IsPostBack = False Then
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

            mdecTotalToday = 0
            mdecTotalPending = 0
        End If

        lblMessageTotal.Text = ""
        lblMessageFee.Text = ""
        lblMessageSuccess.Text = ""


    End Sub

    Protected Sub txtPay_Click(sender As Object, e As EventArgs) Handles btnPay.Click

        'validate selected account balance >= 0


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

        'build the two totals wooooo
        For i = 0 To gvMyPayees.Rows.Count - 1
            Dim t As TextBox = DirectCast(gvMyPayees.Rows(i).Cells(3).FindControl("txtAmount"), TextBox)
            Dim c As Calendar = DirectCast(gvMyPayees.Rows(i).Cells(4).FindControl("calDate"), Calendar)

            If dbdate.CheckSelectedDate(c.SelectedDate) = 0 And t.Text <> "" Then
                mdecTotalToday += CDec(t.Text)
            End If

            If dbdate.CheckSelectedDate(c.SelectedDate) = 1 And t.Text <> "" Then
                mdecTotalPending += CDec(t.Text)
            End If

        Next
        lblMessageTotal.Text = "Total Amount Today = " & mdecTotalToday.ToString("c2") & " and Total Amount Pending = " & mdecTotalPending.ToString("c2")

    End Sub

    Protected Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click

        lblTest.Text = dbdate.CheckSelectedDate(calTest.SelectedDate).ToString

    End Sub

End Class