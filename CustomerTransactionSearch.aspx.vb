Public Class CustomerTransactionSearch
    Inherits System.Web.UI.Page
    Dim DBTransactions As New ClassDBTransactions
    Dim DBAccount As New ClassDBAccounts
    Dim Val As New ClassValidate

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Session("AccountNumber") = 1000000005
            DBTransactions.GetAllTransactions(Session("AccountNumber").ToString)
            DBAccount.GetAccountNameByAccountNumber(Session("AccountNumber"))
            lblAccountName.Text = DBAccount.AccountsDataset5.Tables("tblAccounts").Rows(0).Item("AccountName")
            Search()
        End If
        DBTransactions.GetAllTransactions(Session("AccountNumber").ToString)

    End Sub

    Public Sub Search()
        DBTransactions.DoSort()

        'bind the gridview to the dataview
        gvTransactionSearch.DataSource = DBTransactions.MyView
        gvTransactionSearch.DataBind()

        'error message & table disappears if there are no matching records
        If DBTransactions.MyView.Count = 0 Then
            lblNumberOfTransactions.Text = "No records found"
        Else
            lblNumberOfTransactions.Text = "There are " & DBTransactions.MyView.Count.ToString & " records"
        End If
    End Sub

    Public Sub Clear()
        txtDescriptionSearch.Text = ""
        rblDescription.SelectedValue = Nothing
        ddlSearchByTransactionType.SelectedIndex = 0
        rblPrice.SelectedValue = Nothing
        txtSearchByOtherPriceMax.Text = ""
        txtSearchByOtherPriceMin.Text = ""
        txtSearchByTransactionNumber.Text = ""
        rblDate.SelectedValue = Nothing
        txtCustomDateMin.Text = ""
        For i As Integer = 0 To cblParameters.Items.Count - 1
            cblParameters.Items(i).Selected = Nothing
        Next
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim strDescriptionPartialCode1 As String
        Dim strDescriptionPartialCode2 As String
        Dim strDescriptionKeywordCode1 As String
        Dim strDescriptionKeywordCode2 As String
        strDescriptionPartialCode1 = "Description like '%"
        strDescriptionPartialCode2 = "'"
        strDescriptionKeywordCode1 = "Description like '%"
        strDescriptionKeywordCode2 = "%'"

        Dim strTransactionTypeCode1 As String
        Dim strTransactionTypeCode2 As String
        strTransactionTypeCode1 = "[Transaction Type] like '"
        strTransactionTypeCode2 = "'"

        Dim str0to100 As String
        Dim str101to200 As String
        Dim str201to300 As String
        Dim str300orMore As String
        Dim strPriceCode1 As String
        Dim strPriceCode2 As String
        Dim strPriceCode3 As String
        str0to100 = "Amount > 0 and Amount <=100"
        str101to200 = "Amount > 100 and Amount <=200"
        str201to300 = "Amount > 200 and amount <=300"
        str300orMore = "Amount > 300"
        strPriceCode1 = "Amount >= '"
        strPriceCode2 = "' AND Amount <= '"
        strPriceCode3 = "'"

        Dim strTransactionNumberCode1 As String
        Dim strTransactionNumberCode2 As String
        strTransactionNumberCode1 = "[Transaction Number] like '%"
        strTransactionNumberCode2 = "%'"


        Dim strIn1 As String
        Dim strIn2 As String
        Dim strIn3 As String
        Dim strIn4 As String
        Dim strIn5 As String

        If cblParameters.Items(0).Selected = True Then
            If txtDescriptionSearch.Text = "" Then
                lblError.Text = "If you are searching by description, please enter a description into the Search by Description box"
                Exit Sub
            End If
            If rblDescription.SelectedValue = Nothing Then
                lblError.Text = "If you are searching by description, please select either a partial or a keyword search"
                Exit Sub
            End If
        End If

        If cblParameters.Items(0).Selected = True And rblDescription.SelectedIndex = 0 Then
            strIn1 = strDescriptionPartialCode1 & txtDescriptionSearch.Text & strDescriptionPartialCode2
        End If

        If cblParameters.Items(0).Selected = True And rblDescription.SelectedIndex = 1 Then
            strIn1 = strDescriptionKeywordCode1 & txtDescriptionSearch.Text & strDescriptionKeywordCode2
        End If


        If cblParameters.Items(1).Selected = True Then
            strIn2 = strTransactionTypeCode1 & ddlSearchByTransactionType.SelectedValue.ToString & strTransactionTypeCode2
        End If

        If cblParameters.Items(2).Selected = True Then
            If rblPrice.SelectedIndex = Nothing Then
                lblError.Text = "If you want to search by price, please select a price range to search by"
                Exit Sub
            End If
            If rblPrice.SelectedValue = "Custom Range" Then
                If txtSearchByOtherPriceMax.Text = "" Or txtSearchByOtherPriceMin.Text = "" Then
                    lblError.Text = "Please enter a minimum and a maximum transaction amount"
                    Exit Sub
                End If
                If Val.CheckDecimal(txtSearchByOtherPriceMax.Text) = -1 Then
                    lblError.Text = "Please enter a positive numeric amount as your maximum price"
                    Exit Sub
                End If
                If Val.CheckDecimal(txtSearchByOtherPriceMin.Text) = -1 Then
                    lblError.Text = "Please enter a positive numeric amount as your minimum price"
                    Exit Sub
                End If
            End If
        End If

        If cblParameters.Items(2).Selected = True Then
            If rblPrice.SelectedIndex = 0 Then
                strIn3 = str0to100
            End If
            If rblPrice.SelectedIndex = 1 Then
                strIn3 = str101to200
            End If
            If rblPrice.SelectedIndex = 2 Then
                strIn3 = str201to300
            End If
            If rblPrice.SelectedIndex = 3 Then
                strIn3 = str300orMore
            End If
            If rblPrice.SelectedIndex = 4 Then
                strIn3 = strPriceCode1 & txtSearchByOtherPriceMin.Text & strPriceCode2 & txtSearchByOtherPriceMax.Text & strPriceCode3
            End If
        End If

        If cblParameters.Items(3).Selected = True Then
            If txtSearchByTransactionNumber.Text = "" Then
                lblError.Text = "Please enter a transaction number to search by if you want to search by transaction number"
                Exit Sub
            End If
            If Val.CheckDigits(txtSearchByTransactionNumber.Text) = False Then
                lblError.Text = "Please enter a numeric transaction number to search"
                Exit Sub
            End If
        End If
        If cblParameters.Items(3).Selected = True Then
            strIn4 = strTransactionNumberCode1 & txtSearchByTransactionNumber.Text & strTransactionNumberCode2
        End If

        'systemdate vs date in row

        DBTransactions.Search2Param(strDescriptionKeywordCode1, txtDescriptionSearch.Text, strDescriptionKeywordCode2, "And", strTransactionTypeCode1, ddlSearchByTransactionType.SelectedValue.ToString, strTransactionTypeCode2)

        Search()
        Clear()
    End Sub

    Protected Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Clear()
        'reload gv to original
    End Sub
End Class