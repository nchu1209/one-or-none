Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class ClassDBTransactions
    Dim mDatasetTransactions As New DataSet
    Dim mstrQuery As String
    Dim mdbDataAdapter As New SqlDataAdapter
    Dim mdbConn As New SqlConnection
    Dim mstrConnection As String = "workstation id=COMPUTER;packet size =4096;data source=MISSQL.mccombs.utexas.edu;integrated security=False; initial catalog=mis333k_msbck614; user id=msbck614; password=AmyEnrione1"
    Dim mMyView As New DataView

    Public ReadOnly Property TransactionsDataset() As DataSet
        Get
            'Return dataset to user
            Return mDatasetTransactions
        End Get
    End Property
    Public ReadOnly Property MyView() As DataView
        Get
            Return mMyView
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
            mDatasetTransactions.Clear()
            'open connection and fill dataset
            mdbDataAdapter.Fill(mDatasetTransactions, "tblTransactions")
            'copy dataset to dataview
            mMyView.Table = mDatasetTransactions.Tables("tblTransactions")
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
            mDatasetTransactions.Clear()
            'open connection and fill dataset
            mdbDataAdapter.Fill(mDatasetTransactions, "tblTransactions")
            'copy dataset to dataview
            mMyView.Table = mDatasetTransactions.Tables("tblTransactions")
        Catch ex As Exception
            Throw New Exception("stored procedure is " & strProcedureName.ToString & "parameters are " & strParameterName.ToString & strParameterValue.ToString & " error is " & ex.Message)
        End Try
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
            mDatasetTransactions.Clear()

            'fill the dataset
            mdbDataAdapter.Fill(mDatasetTransactions, "tblTransactions")

            'close the connection
            mdbConn.Close()
        Catch ex As Exception
            Throw New Exception("query is " & strQuery.ToString & " error is " & ex.Message)
        End Try
    End Sub

    Public Sub GetMaxTransactionNumber()
        RunProcedureNoParam("usp_transactions_get_max_transaction_number")
    End Sub

    Public Sub AddTransaction(intTransactionNumber As Integer, ByVal intAccountNumber As Integer, strTransactionType As String, strDate As String, decTransactionAmount As Decimal, strDescription As String, decAccountBalance As Decimal, strIRA As String)
        'Purpose: adds a customer to database
        'Arguments: 11 strings
        'Returns: nothing
        'Author: Nicole Chu (nc7997)
        'Date: 9/24/2014

        mstrQuery = "INSERT INTO tblTransactions (TransactionNumber, AccountNumber, TransactionType, Date, TransactionAmount, Description, AccountBalance, IRA) VALUES (" & _
            "'" & intTransactionNumber & "', " & _
            "'" & intAccountNumber & "', " & _
            "'" & strTransactionType & "', " & _
            "'" & strDate & "', " & _
            "'" & decTransactionAmount & "', " & _
            "'" & strDescription & "', " & _
            "'" & decAccountBalance & "', " & _
            "'" & strIRA & "')"

        'use UpdateDB sub to update database
        UpdateDB(mstrQuery)
    End Sub
    Public Sub DoSort()
        MyView.Sort = "[Transaction Number], [Transaction Type], Description, Amount, Date"
    End Sub

    Public Sub GetAllTransactions(strAccountNumber As String)
        RunProcedureOneParameter("usp_transactions_get_all", "@AccountNumber", strAccountNumber)
    End Sub
    Public Sub Search2Param(strCode1 As String, strValue1 As String, strCode2 As String, strAndOR As String, str3 As String, strValue2 As String, str4 As String)
        MyView.RowFilter = strCode1 & strValue1 & strCode2 & strAndOR & str3 & strValue2 & str4
    End Sub

    Public Sub SearchByDescriptionKeyword(strKeyword As String)
        MyView.RowFilter = "Description like '%" & strKeyword & "%'"
    End Sub

    Public Sub SearchByTransactionType(strIn As String)
        MyView.RowFilter = "[Transaction Type] like '" & strIn & "'"
    End Sub
End Class
