Public Class CustomerBillDetail
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("CustomerNumber") Is Nothing Then
            Response.Redirect("CustomerLogin.aspx")
        End If

        If Request.QueryString("ID") Is Nothing Then
            Response.Redirect("CustomerPayBills.aspx")
        End If

        lblTest.Text = Request.QueryString("ID")
    End Sub

End Class