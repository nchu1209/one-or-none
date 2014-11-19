Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class ClassDBAccounts
    'Declare module-level variables
    Dim mDatasetAccounts As New DataSet
    Dim mDatasetAccounts2 As New DataSet
    Dim mstrQuery As String
    Dim mdbDataAdapter As New SqlDataAdapter
    Dim mdbConn As New SqlConnection
    Dim mstrConnection As String = "workstation id=COMPUTER;packet size =4096;data source=MISSQL.mccombs.utexas.edu;integrated security=False; initial catalog=mis333k_msbck614; user id=msbck614; password=AmyEnrione1"
    Dim mMyView As New DataView
    Dim mMyView2 As New DataView

    Public ReadOnly Property AccountsDataset() As DataSet
        Get
            'Return dataset to user
            Return mDatasetAccounts
        End Get
    End Property
    Public ReadOnly Property MyView() As DataView
        Get
            Return mMyView
        End Get
    End Property


    Public ReadOnly Property AccountsDataset2() As DataSet
        Get
            'Return dataset to user
            Return mDatasetAccounts2
        End Get
    End Property
    Public ReadOnly Property MyView2() As DataView
        Get
            Return mMyView2
        End Get
    End Property


    Public Sub UpdateDB(ByVal mstrQuery As String)
        'Purpose: run given query to update database
        'Arguments: 1 string (any SQL statement)
        'Returns: nothing
        'Author: Nicole Chu (nc7997)
        'Date: 9/24/2014

        Try
            'make connection using the connection string
            mdbConn = New SqlConnection(mstrConnection)
            Dim dbCommand As New SqlCommand(mstrQuery, mdbConn)

            'open the connection
            mdbConn.Open()

            'run query
            dbCommand.ExecuteNonQuery()

            'close the connection
            mdbConn.Close()
        Catch ex As Exception
            Throw New Exception("query is " & mstrQuery.ToString & " error is " & ex.Message)
        End Try

    End Sub

    Public Sub RunProcedureNoParam(ByVal strProcedureName As String)
        'Purpose: run any stored procedure with no parameters and fill dataset
        'Arguments: 1 string that contains procedure name
        'Returns: none (query results via property)
        'Author: Nicole Chu (nc7997)
        'Date: 10/21/14
        'Creates instances of the connection and command object
        Dim objConnection As New SqlConnection(mstrConnection)
        'Tell SQL server the name of the stored procedure you will be executing
        Dim mdbDataAdapter As New SqlDataAdapter(strProcedureName, objConnection)
        Try
            'sets command type to "stored procedure"
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            'clear dataset
            mDatasetAccounts.Clear()
            'open connection and fill dataset
            mdbDataAdapter.Fill(mDatasetAccounts, "tblAccounts")
            'copy dataset to dataview
            mMyView.Table = mDatasetAccounts.Tables("tblAccounts")
        Catch ex As Exception
            Throw New Exception("stored procedure is " & strProcedureName.ToString & " error is " & ex.Message)
        End Try
    End Sub


    Public Sub RunProcedureCustomerNumber(ByVal strProcedureName As String)
        'Purpose: run any stored procedure with no parameters and fill dataset
        'Arguments: 1 string that contains procedure name
        'Returns: none (query results via property)
        'Author: Nicole Chu (nc7997)
        'Date: 10/21/14
        'Creates instances of the connection and command object
        Dim objConnection As New SqlConnection(mstrConnection)
        'Tell SQL server the name of the stored procedure you will be executing
        Dim mdbDataAdapter As New SqlDataAdapter(strProcedureName, objConnection)
        Try
            'sets command type to "stored procedure"
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            'clear dataset
            mDatasetAccounts2.Clear()
            'open connection and fill dataset
            mdbDataAdapter.Fill(mDatasetAccounts2, "tblAccounts")
            'copy dataset to dataview
            mMyView2.Table = mDatasetAccounts2.Tables("tblAccounts")
        Catch ex As Exception
            Throw New Exception("stored procedure is " & strProcedureName.ToString & " error is " & ex.Message)
        End Try
    End Sub



    Public Sub RunProcedureOneParameter(ByVal strProcedureName As String, ByVal strParameterName As String, ByVal strParameterValue As String)
        'Purpose: run any stored procedure with one parameter and fill dataset
        'Arguments: 3 strings
        'Returns: none (query results via property)
        'Author: Nicole Chu (nc7997)
        'Date: 10/21/14
        'Creates instances of the connection and command object
        Dim objConnection As New SqlConnection(mstrConnection)
        'Tell SQL server the name of the stored procedure you will be executing
        Dim mdbDataAdapter As New SqlDataAdapter(strProcedureName, objConnection)
        Try
            'sets command type to "stored procedure"
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            'add parameter to SPROC
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter(strParameterName, strParameterValue))
            'clear dataset
            mDatasetAccounts.Clear()
            'open connection and fill dataset
            mdbDataAdapter.Fill(mDatasetAccounts, "tblAccounts")
            'copy dataset to dataview
            mMyView.Table = mDatasetAccounts.Tables("tblAccounts")
        Catch ex As Exception
            Throw New Exception("stored procedure is " & strProcedureName.ToString & "parameters are " & strParameterName.ToString & strParameterValue.ToString & " error is " & ex.Message)
        End Try
    End Sub

    Public Sub LinkZip(ByVal strCustomerID As String)
        RunProcedureOneParameter("usp_innerjoin_customer_city_by_zip", "@CustomerID", strCustomerID)
    End Sub

    Public Sub CustomerNumber()
        RunProcedureCustomerNumber("usp_customer_number")
    End Sub

    Public Sub GetByCustomerNumber(strCustomerNumber As String)
        RunProcedureOneParameter("usp_customers_get_by_customer_number", "@CustomerNumber", strCustomerNumber)
    End Sub

    Public Sub GetAllAccounts()
        RunProcedureNoParam("usp_accounts_get_all")
    End Sub

    Public Sub GetMaxAccountNumber()
        RunProcedureNoParam("usp_accounts_get_max_account_number")
    End Sub

    Public Sub AddAccount(intCustomerID As Integer, ByVal intAccountNumber As Integer, ByVal strAccountName As String, ByVal strAccountType As String, ByVal strActive As String, ByVal strManagerApprovedDeposit As String, ByVal intInitial As Integer, ByVal intBalance As Integer)
        'Purpose: adds a customer to database
        'Arguments: 11 strings
        'Returns: nothing
        'Author: Nicole Chu (nc7997)
        'Date: 9/24/2014

        mstrQuery = "INSERT INTO tblAccounts (CustomerID, AccountNumber, AccountName, AccountType, Active, ManagerApprovedDeposit, Initial, Balance) VALUES (" & _
            "'" & intCustomerID & "', " & _
            "'" & intAccountNumber & "', " & _
            "'" & strAccountName & "', " & _
            "'" & strAccountType & "', " & _
            "'" & strActive & "', " & _
            "'" & strManagerApprovedDeposit & "', " & _
            "'" & intInitial & "', " & _
            "'" & intBalance & "')"

        'use UpdateDB sub to update database
        UpdateDB(mstrQuery)

    End Sub
    Public Sub SelectQuery(ByVal strQuery As String)
        'Purpose: run any select query and fill dataset
        'Arguments: 1 string that contains query
        'Returns: none (query results via property)
        'Author: Nicole Chu (nc7997)
        'Date: 9/18/2014

        Try
            'define data connection and data adapter
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter(strQuery, mdbConn)

            'open the connection and dataset
            mdbConn.Open()

            'clear the dataset before filling
            mDatasetAccounts.Clear()

            'fill the dataset
            mdbDataAdapter.Fill(mDatasetAccounts, "tblAccounts")

            'close the connection
            mdbConn.Close()
        Catch ex As Exception
            Throw New Exception("query is " & strQuery.ToString & " error is " & ex.Message)
        End Try

    End Sub



End Class
