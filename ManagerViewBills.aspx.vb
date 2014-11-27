Option Strict On

Public Class ManagerViewBills
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("EmployeeFirstName") Is Nothing Then
            Response.Redirect("EmployeeLogin.aspx")
        End If


    End Sub

End Class