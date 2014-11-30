Public Class CustomerTransactionSearch
    Inherits System.Web.UI.Page
    Dim DBTransactions As New ClassDBTransactions
    Dim DBAccount As New ClassDBAccounts

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
        rblDescriptionAO.SelectedValue = Nothing
        ddlSearchByTransactionType.SelectedIndex = 0
        rblTransactionTypeAO.SelectedValue = Nothing
        rblPrice.SelectedValue = Nothing
        rblPriceAO.SelectedValue = Nothing
        txtSearchByOtherPriceMax.Text = ""
        txtSearchByOtherPriceMin.Text = ""
        txtSearchByTransactionNumber.Text = ""
        rblTransactionNumberAO.SelectedValue = Nothing
        rblDate.SelectedValue = Nothing
        rblDateAO.SelectedValue = Nothing
        txtCustomDateSearch.Text = ""
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

        ' code - value - code
        Dim strMin
        If rblPrice.SelectedIndex = 0 Then

        End If
        Dim str0to1001 As String
        Dim str0to1002 As String
        str0to1001 = "Amount >= 0 and"
        str0to1002 = ""

        Dim strIn1 As String
        Dim strIn2 As String
        Dim strIn3 As String
        Dim strIn4 As String
        Dim strIn5 As String
        Dim strAndOr1 As String
        Dim strAndOr2 As String
        Dim strAndOr3 As String
        Dim strAndOr4 As String
        Dim strAndOr5 As String


        If rblDescriptionAO.SelectedIndex = 0 Then
            strAndOr1 = "And"
        ElseIf rblDescriptionAO.SelectedIndex = 1 Then
            strAndOr1 = "Or"
        End If

        ''''can we do or?
        ' and or or goes BEFORE info
        'ie I want to search by "or date"
        'therefore strandor4 must go before date
        'how do we handle the first one 

        If rblDescriptionAO.SelectedIndex = 0 And rblDescription.SelectedIndex = 0 Then
            strAndOr1 = "And"
            strIn1 = strDescriptionPartialCode1 & txtDescriptionSearch.Text & strDescriptionPartialCode2
        ElseIf rblDescriptionAO.SelectedIndex = 0 And rblDescription.SelectedIndex = 1 Then
            strAndOr1 = "And"
            strIn1 = strDescriptionKeywordCode1 & txtDescriptionSearch.Text & strDescriptionKeywordCode2
        ElseIf rblDescriptionAO.SelectedIndex = 1 And rblDescription.SelectedIndex = 0 Then
            strAndOr1 = "Or"
            strIn1 = strDescriptionPartialCode1 & txtDescriptionSearch.Text & strDescriptionPartialCode2
        ElseIf rblDescriptionAO.SelectedIndex = 1 And rblDescription.SelectedIndex = 1 Then
            strAndOr1 = "Or"
            strIn1 = strDescriptionKeywordCode1 & txtDescriptionSearch.Text & strDescriptionKeywordCode2
        Else
            st()
        End If

        If rblTransactionTypeAO.SelectedIndex = 0 Then
            strAndOr2 = "And"
        End If

        DBTransactions.Search2Param(strDescriptionKeywordCode1, txtDescriptionSearch.Text, strDescriptionKeywordCode2, "And", strTransactionTypeCode1, ddlSearchByTransactionType.SelectedValue.ToString, strTransactionTypeCode2)

        Search()
        lblNumberOfTransactions.Text = rblDescriptionAO.SelectedValue.ToString
        Clear()
    End Sub

    Protected Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Clear()
    End Sub
End Class