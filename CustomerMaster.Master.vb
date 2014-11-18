Public Class CustomerMaster
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblName.Text = Session("CustomerFirstName").ToString
        lblName2.Text = Session("CustomerFirstName").ToString
    End Sub

    Protected Sub lnkLogout_Click(sender As Object, e As EventArgs) Handles lnkLogout.Click
        Session("CustomerNumber") = Nothing
        Session("CustomerFirstName") = Nothing
        Response.Redirect("CustomerLogin.aspx")
    End Sub
End Class