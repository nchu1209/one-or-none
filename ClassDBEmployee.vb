Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class ClassDBEmployee

    'Declare module-level variables
    Dim mDatasetEmployee As New DataSet
    Dim mstrQuery As String
    Dim mdbDataAdapter As New SqlDataAdapter
    Dim mdbConn As New SqlConnection
    Dim mstrConnection As String = "workstation id=COMPUTER;packet size =4096;data source=MISSQL.mccombs.utexas.edu;integrated security=False;initial catalog=mis333k_msbck614;user id=msbck614;password=AmyEnrione1"
    Dim mMyView As New DataView
    Private _session As String


    'Purpose:to set the property of the dataset
    'Arguments: none
    'Returns: mDatasetEmployee
    'Author: Leah Carroll
    'Date: 10-19-2014
    ' define a public read only property for the outside world to access the dataset filled by this class
    Public ReadOnly Property EmpDataset() As DataSet
        Get
            ' return dataset to user
            Return mDatasetEmployee
        End Get
    End Property

    'Purpose:to set the propert of myview
    'Arguments: none
    'Returns: Me.mMyView
    'Author: Leah Carroll
    'Date: 10-19-2014
    Public ReadOnly Property MyView() As DataView
        Get
            Return Me.mMyView
        End Get
    End Property



    'Purpose: run any select query and fill dataset
    'Arguments: strQuery
    'returns: the dataset
    ' Author: Leah Carroll
    'Date: 9-18-2014
    Public Sub SelectQuery(ByVal strQuery As String)

        Try
            ' define data connection and data adapter
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter(strQuery, mdbConn)

            ' open the connection and dataset 
            mdbConn.Open()

            ' clear the dataset before filling
            mDatasetemployee.Clear()

            ' fill the dataset
            mdbDataAdapter.Fill(mDatasetEmployee, "tblemployees")

            ' close the connection
            mdbConn.Close()
        Catch ex As Exception
            Throw New Exception("query is " & strQuery.ToString & "error is " & ex.Message)
        End Try

    End Sub



    'Purpose:to read the inputed password and to return if it is valid or not
    'Arguments:password 
    'Returns: if the password is valid or not (True or False)
    'Author: Leah Carroll
    'Date: 9-18-2014
    Public Function CheckPassword(strPassword As String) As Boolean

        If strPassword = MyView(0).Item("password").ToString Then
            Return True
        Else
            Return False
        End If

    End Function


    'Purpose:to run a prcedure in the db that has no parameters
    'Arguments: the strName
    'Returns: none, just updates the view
    'Author: Leah Carroll
    'Date: 10-19-2014
    Public Sub RunProcedure(strName As String)
        'CREATES INSTANCES OF THE CONNECTION AND COMAND OBJECT
        Dim objConnection As New SqlConnection(mstrConnection)
        'Tell SQL server the name of the stored procedure you will be executing
        Dim objCommand As New SqlDataAdapter(strName, objConnection)
        Try
            'SETS THE COMMAND TYPE TO "STORED PROCEDURE
            objCommand.SelectCommand.CommandType = CommandType.StoredProcedure
            'clear dataset
            Me.mDatasetemployee.Clear()
            'OPEN CONNECTION AND FILL DATASET
            objCommand.Fill(mDatasetEmployee, "tblEmployees")
            'copy dataset to dataview
            mMyView.Table = mDatasetEmployee.Tables("tblEmployees")
        Catch ex As Exception
            Throw New Exception("stored procedure is " & strName.ToString & " error is " & ex.Message)
        End Try

    End Sub



    'Purpose:to get all employees through a stored procedure
    'Arguments: none
    'Returns: none directly, but returns the employee information
    'Author: Leah Carroll
    'Date: 10-20-2014
    Public Sub GetAllEmployeesUsingSP()
        RunProcedure("usp_employees_get_all")
    End Sub


    'Purpose:to search by the typed empid
    'Arguments: the strIN
    'Returns: True or false
    'Author: Leah Carroll
    'Date: 10-20-2014
    Public Function SearchByEmpID(strIN As String) As Boolean

        MyView.RowFilter = "empID='" & strIN & "'"

        If mMyView.Count = 0 Then
            Return False
        End If

        Return True
    End Function


    'Purpose:to get the record according to the ID
    'Arguments: the username input by the user
    'Returns: if the username is valid or not
    'Author: Leah Carroll
    'Date: 9-18-2014
    Public Sub GetByEmpID(strEmpID As String)
        mstrQuery = "Select * from tblEmployees where empID = '" & strEmpID & "'"
        SelectQuery(mstrQuery)
    End Sub


    'Purpose:to modify the customer in the db
    'Arguments: all of the fields that are inputted when modifying customer such as the username, password, first name, last name, recordID
    'Returns: none
    'Author: Leah Carroll
    'Date: 10-5-2014
    Public Sub ModifyEmployeeAddress(strAddress As String, strZipcode As String, strEmpID As String)
        'the strquery that will be modified
        mstrQuery = "UPDATE tblEmployees SET Address= '" & strAddress & _
            "', Zipcode = '" & strZipcode & _
            "'where EmpID = " & strEmpID

        'updates the db
        UpdateDB(mstrQuery)

    End Sub

    'Purpose:to modify the customer in the db
    'Arguments: all of the fields that are inputted when modifying customer such as the username, password, first name, last name, recordID
    'Returns: none
    'Author: Leah Carroll
    'Date: 10-5-2014
    Public Sub ModifyEmployeePhone(strPhone As String, strEmpID As String)
        'the strquery that will be modified
        mstrQuery = "UPDATE tblEmployees SET Phone= '" & strPhone & _
            "'where EmpID = " & strEmpID

        'updates the db
        UpdateDB(mstrQuery)

    End Sub

    'Purpose: run given query to update db
    'Argument: one string (any SQL statement)
    'returns: nothing
    'Author: Leah Carroll
    'Date: 9-23-2014
    Public Sub UpdateDB(strQuery As String)

        Try
            'make connection using the connection string above
            mdbConn = New SqlConnection(mstrConnection)
            Dim dbCommand As New SqlCommand(strQuery, mdbConn)

            'open the connection
            mdbConn.Open()

            'run the query
            dbCommand.ExecuteNonQuery()

            'close the connection
            mdbConn.Close()

        Catch ex As Exception
            Throw New Exception("query is " & strQuery.ToString & " error is " & ex.Message)

        End Try
    End Sub



    Public Sub ModifyPassword(strPassword As String, ByVal intEmployeeID As Integer)

        mstrQuery = "UPDATE tblEmployees SET " & _
            "Password = '" & strPassword & "' " & _
            "WHERE EmpID = " & intEmployeeID

        'use UpdateDB sub to update database
        UpdateDB(mstrQuery)

    End Sub
End Class
