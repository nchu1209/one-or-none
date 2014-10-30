Public Class HelloWorld
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblMessage.Text = ""
    End Sub

    Protected Sub btnClick_Click(sender As Object, e As EventArgs) Handles btnClick.Click
        lblMessage.Text = "Hello World! :D"
    End Sub
End Class