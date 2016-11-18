Imports System.Data.SqlClient
Public Class CreateStreams
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Sub ExecuteSQL(ByVal SQLString As String)
        Using connection As New SqlConnection("server=HPV4SQLDEV;uid=sa;pwd=RadianT1;database=Centegra_IC_DEV")
            Dim command As New SqlCommand(SQLString, connection)
            command.Connection.Open()
            command.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub btnExecute_Click(sender As Object, e As EventArgs) Handles btnExecute.Click
        Dim CountInTable As Integer = 2135

        Dim NumberOfStreams As Integer = 4

        Dim myConnection As New SqlConnection("server=HPV4SQLDEV;uid=sa;pwd=RadianT1;database=Centegra_IC_DEV")
        myConnection.Open()
        Dim MyCommand As New SqlCommand("SELECT TransactionID FROM ETL_V2_Transactions", myConnection)
        Dim myReader As SqlDataReader = MyCommand.ExecuteReader()
        While myReader.Read()
            ExecuteSQL("UPDATE ETL_V2_Transactions SET StreamID = 1 WHERE TransactionID = " & myReader("TransactionID"))
        End While
        myReader.Close()
        myReader.Dispose()
        MyCommand.Dispose()
        myConnection.Close()
        myConnection.Dispose()
    End Sub
End Class