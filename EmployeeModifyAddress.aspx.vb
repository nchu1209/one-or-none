Public Class EmployeeModifyAddress
    Inherits System.Web.UI.Page

    'declare classes
    Dim valid As New ClassEmployeeValidation
    Dim DB As New ClassDBEmployee


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        'when form loads
        If IsPostBack = False Then
            Try
                'get record id from session
                Dim strEmpID As String
                Session("EmpID") = 2002
                strEmpID = Session("EmpID")


                'get that custoemrs record
                DB.GetByEmpID(strEmpID)
                'fill textboxes
                FillTextboxes()
            Catch ex As Exception
                'redirects if information is not provided
                Response.Redirect("EmployeeLogin.aspx")
                Throw New Exception("emp id from session is " & Session("EmpID").ToString)
            End Try
        End If

    End Sub


    Protected Sub btnModifyAddress_Click(sender As Object, e As EventArgs) Handles btnModifyAddress.Click


        'reset the label
        lblError.Text = ""

        'need this to be the index. not the  ID
        Dim intRow As Integer
        intRow = Session("EmpID").ToString


        'check zip code
        If txtZipcode.Text <> "" Then
            If valid.CheckZip(txtZipcode.Text) = False Then
                'err msg
                lblError.Text = "Zip code is invalid."
                'exit sub
                Exit Sub
            End If
        End If


        'the record validator check
        If Not IsValid Then
            Exit Sub
        End If

        'output that the record was added
        lblError.Text = "Record Modified."

        'QUERY STUFF

        ' runupdate query to modify record
        Dim strRow As String
        strRow = Session("EmpID").ToString

        ''get that custoemrs reord
        'DB.GetByEmpID(strRow)

        'modify the DB
        DB.ModifyEmployeeAddress(txtAddress.Text, txtZipcode.Text, strRow)

        'call next page(EmployeeHome)
        Response.AddHeader("Refresh", "2; URL=EmployeeHome.aspx")


    End Sub


    'Purpose: filling the textboxes
    'Arguments: none
    'returns: the values to the textboxes when called
    ' Author: Leah Carroll
    'Date: 10-6- 2014
    Public Sub FillTextboxes()
        'put info from selected customer into text boxes on form
        Dim intRow As Integer
        intRow = 0


        txtZipcode.Text = DB.EmpDataset.Tables("tblEmployees").Rows(intRow).Item("Zipcode")
        txtAddress.Text = DB.EmpDataset.Tables("tblEmployees").Rows(intRow).Item("Address")

       
    End Sub



End Class