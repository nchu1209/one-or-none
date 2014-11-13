Public Class CustomerPerformTransaction
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then
            SetFormNormal()
        End If



    End Sub


    Private Sub SetFormNormal()
        WithdrawalPanel.Visible = False
        DepositPanel.Visible = False
        TransferPanel.Visible = False
    End Sub

    Protected Sub ddlTransactions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlTransactions.SelectedIndexChanged
        SetFormNormal()
        If ddlTransactions.SelectedValue = "Withdrawal" Then
            WithdrawalPanel.Visible = True
        End If

        If ddlTransactions.SelectedValue = "Deposit" Then
            DepositPanel.Visible = True
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
End Class