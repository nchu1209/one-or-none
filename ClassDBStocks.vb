﻿Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class ClassDBStocks


    'Declare module-level variables
    Dim mDatasetStocks As New DataSet
    Dim mDatasetStocks2 As New DataSet
    Dim mDatasetStocks3 As New DataSet
    Dim mstrQuery As String
    Dim mdbDataAdapter As New SqlDataAdapter
    Dim mdbConn As New SqlConnection
    Dim mstrConnection As String = "workstation id=COMPUTER;packet size =4096;data source=MISSQL.mccombs.utexas.edu;integrated security=False;initial catalog=mis333k_msbck614;user id=msbck614;password=AmyEnrione1"
    Dim mMyView As New DataView
    Dim mMyView2 As New DataView
    Dim mMyView3 As New DataView
    Private _session As String

    Public ReadOnly Property StocksDataset() As DataSet
        Get
            ' return dataset to user
            Return mDatasetStocks
        End Get
    End Property

    Public ReadOnly Property MyView() As DataView
        Get
            Return Me.mMyView
        End Get
    End Property

    Public ReadOnly Property StocksDataset2() As DataSet
        Get
            ' return dataset to user
            Return mDatasetStocks2
        End Get
    End Property

    Public ReadOnly Property MyView2() As DataView
        Get
            Return Me.mMyView2
        End Get
    End Property


    Public ReadOnly Property StocksDataset3() As DataSet
        Get
            ' return dataset to user
            Return mDatasetStocks2
        End Get
    End Property

    Public ReadOnly Property MyView3() As DataView
        Get
            Return Me.mMyView2
        End Get
    End Property


    Public Sub SelectQuery(ByVal strQuery As String)

        Try
            ' define data connection and data adapter
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter(strQuery, mdbConn)

            ' open the connection and dataset 
            mdbConn.Open()

            ' clear the dataset before filling
            mDatasetStocks.Clear()

            ' fill the dataset
            mdbDataAdapter.Fill(mDatasetStocks, "tblStocks")

            ' close the connection
            mdbConn.Close()
        Catch ex As Exception
            Throw New Exception("query is " & strQuery.ToString & "error is " & ex.Message)
        End Try

    End Sub



    Public Sub RunProcedureNoParam(strName As String)
        'CREATES INSTANCES OF THE CONNECTION AND COMAND OBJECT
        Dim objConnection As New SqlConnection(mstrConnection)
        'Tell SQL server the name of the stored procedure you will be executing
        Dim objCommand As New SqlDataAdapter(strName, objConnection)
        Try
            'SETS THE COMMAND TYPE TO "STORED PROCEDURE
            objCommand.SelectCommand.CommandType = CommandType.StoredProcedure
            'clear dataset
            Me.mDatasetStocks.Clear()
            'OPEN CONNECTION AND FILL DATASET
            objCommand.Fill(mDatasetStocks, "tblStocks")
            'copy dataset to dataview
            mMyView.Table = mDatasetStocks.Tables("tblStocks")
        Catch ex As Exception
            Throw New Exception("stored procedure is " & strName.ToString & " error is " & ex.Message)
        End Try

    End Sub

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


    Public Sub RunProcedureOneParameter(ByVal strProcedureName As String, ByVal strParameterName As String, ByVal strParameterValue As String)

        Dim objConnection As New SqlConnection(mstrConnection)
        'Tell SQL server the name of the stored procedure you will be executing
        Dim mdbDataAdapter As New SqlDataAdapter(strProcedureName, objConnection)
        Try
            'sets command type to "stored procedure"
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            'add parameter to SPROC
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter(strParameterName, strParameterValue))
            'clear dataset
            mDatasetStocks.Clear()
            'open connection and fill dataset
            mdbDataAdapter.Fill(mDatasetStocks, "tblStocks")
            'copy dataset to dataview
            mMyView.Table = mDatasetStocks.Tables("tblStocks")
        Catch ex As Exception
            Throw New Exception("stored procedure is " & strProcedureName.ToString & "parameters are " & strParameterName.ToString & strParameterValue.ToString & " error is " & ex.Message)
        End Try
    End Sub



    Public Sub RunProcedureOneParameter2(ByVal strProcedureName As String, ByVal strParameterName As String, ByVal strParameterValue As String)

        Dim objConnection As New SqlConnection(mstrConnection)
        'Tell SQL server the name of the stored procedure you will be executing
        Dim mdbDataAdapter As New SqlDataAdapter(strProcedureName, objConnection)
        Try
            'sets command type to "stored procedure"
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            'add parameter to SPROC
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter(strParameterName, strParameterValue))
            'clear dataset
            mDatasetStocks2.Clear()
            'open connection and fill dataset
            mdbDataAdapter.Fill(mDatasetStocks2, "tblStocks")
            'copy dataset to dataview
            mMyView2.Table = mDatasetStocks2.Tables("tblStocks")
        Catch ex As Exception
            Throw New Exception("stored procedure is " & strProcedureName.ToString & "parameters are " & strParameterName.ToString & strParameterValue.ToString & " error is " & ex.Message)
        End Try
    End Sub


    'Public Sub RunProcedureOneParameter3(ByVal strProcedureName As String, ByVal strParameterName As String, ByVal strParameterValue As String)

    '    Dim objConnection As New SqlConnection(mstrConnection)
    '    'Tell SQL server the name of the stored procedure you will be executing
    '    Dim mdbDataAdapter As New SqlDataAdapter(strProcedureName, objConnection)
    '    Try
    '        'sets command type to "stored procedure"
    '        mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
    '        'add parameter to SPROC
    '        mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter(strParameterName, strParameterValue))
    '        'clear dataset
    '        mDatasetStocks3.Clear()
    '        'open connection and fill dataset
    '        mdbDataAdapter.Fill(mDatasetStocks3, "tblStocks")
    '        'copy dataset to dataview
    '        mMyView3.Table = mDatasetStocks3.Tables("tblStocks")
    '    Catch ex As Exception
    '        Throw New Exception("stored procedure is " & strProcedureName.ToString & "parameters are " & strParameterName.ToString & strParameterValue.ToString & " error is " & ex.Message)
    '    End Try
    'End Sub




    Public Sub GetAllStocks()
        RunProcedureNoParam("usp_stocks_get_all")
    End Sub


    Public Function CheckTickerSP(strTicker As String) As Boolean
        RunProcedureOneParameter("usp_stocks_get_ticker", "@TickerSymbol", strTicker)

        If mDatasetStocks.Tables("tblStocks").Rows.Count <> 0 Then
            Return True
        End If

        Return False
    End Function

    Public Sub GetByStockTicker(strTicker As String)
        RunProcedureOneParameter2("usp_stocks_get_by_ticker", "@Ticker", strTicker)
    End Sub

    Public Sub AddStock(strStockType As String, strTicker As String, strStockName As String, strSharePrice As String, strTransactionFee As String)
        'Purpose: adds a stock to database
        'Arguments: strings
        'Returns: nothing
        'Author: Leah Carroll
        'Date: 11/25/2014

        mstrQuery = "INSERT INTO tblStocks (StockType, TickerSymbol, Name, SalesPrice, Fee) VALUES (" & _
            "'" & strStockType & "', " & _
            "'" & strTicker & "', " & _
            "'" & strStockName & "', " & _
            "'" & strSharePrice & "', " & _
            "'" & strTransactionFee & "')"

        'use UpdateDB sub to update database
        UpdateDB(mstrQuery)

    End Sub

    Public Sub GetByTickerSymbol(strTicker As String)
        mstrQuery = "Select * from tblStocks where TickerSymbol= '" & strTicker & "'"
        SelectQuery(mstrQuery)
    End Sub




    Public Sub ModifyStockPrice(strPrice As String, strTicker As String)
        'the strquery that will be modified
        mstrQuery = "UPDATE tblStocks SET SalesPrice= " & strPrice & _
            " where TickerSymbol = '" & strTicker & "'"

        'updates the db
        UpdateDB(mstrQuery)

    End Sub


End Class
