Public Class CustomerLogin
    Inherits System.Web.UI.Page

    'declare instance of Cust DB
    Dim DB As New ClassDBCustomer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        'check if empID exists in DB; if bad, add 1 to session count
        If DB.CheckEmail(txtEmail.Text) = False Then
            'empID is invalid, return error
            lblError.Text = "ERROR: Email address does not exist in database."
            Exit Sub
        End If

        'check password
        If DB.CheckPassword(txtEmail.Text, txtPassword.Text) = False Then
            'invalid password, return error
            lblError.Text = "ERROR: Invalid password."
            Exit Sub
        End If

        lblError.Text = "YA"

        Session("CustomerFirstName") = DB.CustDataset.Tables("tblCustomers").Rows(0).Item("FirstName")
        Session("CustomerNumber") = DB.CustDataset.Tables("tblCustomers").Rows(0).Item("CustomerNumber")
        Response.Redirect("CustomerHome.aspx")

    End Sub
End Class