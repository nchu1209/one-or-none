Option Strict On

Public Class CustomerManageAccount
    Inherits System.Web.UI.Page

    Dim DB As New ClassDBCustomer

    Dim mCustomerID As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        mCustomerID = 10046
        DB.LinkZip(mCustomerID.ToString)
        FillTextboxes()

    End Sub

    Private Sub FillTextboxes()
        
        'declare variables
        Dim strPhone As String

        'populate variables
        strPhone = DB.CustDataset.Tables("tblCustomers").Rows(0).Item("phone").ToString

        'fill textboxes
        txtLastName.Text = DB.CustDataset.Tables("tblCustomers").Rows(0).Item("lastname").ToString
        txtFirstName.Text = DB.CustDataset.Tables("tblCustomers").Rows(0).Item("firstname").ToString
        txtInitial.Text = DB.CustDataset.Tables("tblCustomers").Rows(0).Item("MI").ToString
        txtPassword.Text = DB.CustDataset.Tables("tblCustomers").Rows(0).Item("password").ToString
        txtAddress.Text = DB.CustDataset.Tables("tblCustomers").Rows(0).Item("address").ToString
        txtCity.Text = DB.CustDataset.Tables("tblCustomers").Rows(0).Item("city").ToString
        txtState.Text = DB.CustDataset.Tables("tblCustomers").Rows(0).Item("state").ToString
        txtZip.Text = DB.CustDataset.Tables("tblCustomers").Rows(0).Item("zipcode").ToString
        txtEmail.Text = DB.CustDataset.Tables("tblCustomers").Rows(0).Item("emailaddr").ToString

    End Sub


End Class