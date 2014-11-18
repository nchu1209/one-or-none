Public Class EmployeeMaster
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblName.Text = Session("EmployeeFirstName").ToString
        lblName2.Text = Session("EmployeeFirstName").ToString
    End Sub

    Protected Sub lnkLogout_Click(sender As Object, e As EventArgs) Handles lnkLogout.Click
        Session("EmpID") = Nothing
        Session("EmployeeFirstName") = Nothing
        Response.Redirect("EmployeeLogin.aspx")
    End Sub
End Class

