Public Class EmployeeLogin
    Inherits System.Web.UI.Page

    'declare instance of Cust DB
    Dim EmpDB As New ClassDBEmployee
    Dim valid As New ClassEmployeeValidation

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        'check login credentials for employee
        'Declarations
        Dim strEmployeeID As String
        Dim strPassword As String


        'set variables to what is in the textboxes
        strEmployeeID = txtEmployeeID.Text
        strPassword = txtPassword.Text

        'check username
        EmpDB.GetAllEmployeesUsingSP()

        'making sure there are no letters and only digits
        If valid.CheckDigits(strEmployeeID) = False Then
            lblError.Text = "ERROR: Invalid EmpID."
            Exit Sub
        End If

        'if bad password messsage and exit sub
        If EmpDB.SearchByEmpID(strEmployeeID) = False Then
            lblError.Text = "ERROR: Invalid EmpID."
            Exit Sub
        End If


        'if bad password messsage and exit sub
        If EmpDB.CheckPassword(strPassword) = False Then
            lblError.Text = "ERROR: Invalid Password."
            Exit Sub
        End If

        'once we get through that they are allowed to access other pages
        Session("Count") = 1

        'IF THEY GET A CORRECT LOGIN
        'create session EMpType and store this employees emptype there for next form
        Session("empType") = EmpDB.EmpDataset.Tables("tblEmployees").Rows(0).Item("empType").ToString 'will get from row zero in emp dataset


        'create session for recordID for next webpage
        Session("EmpID") = EmpDB.EmpDataset.Tables("tblEmployees").Rows(0).Item("empID").ToString

        'call next page(view customers)
        Response.Redirect("EmployeeHome.aspx")

    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        'so they can not access the search page without logging in
        If IsPostBack = False Then
            Session("Count") = 0
        End If
    End Sub


End Class