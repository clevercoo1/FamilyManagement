Imports Npgsql

Public Class Form1

#Region "Test"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim conn = New NpgsqlConnection("Host=localhost;Username=postgres;Password=a789889;Database=shop;CommandTimeout=50;Integrated Security=true")
            Dim strPLSql As String = String.Empty
            Dim ds As New DataSet
            Dim da As NpgsqlDataAdapter
            da = New NpgsqlDataAdapter("SELECT * FROM shohin where shohin_id = '0001'", conn)
            da.Fill(ds)
            TextBox1.Text = ds.Tables(0).Rows(0).Item(0).ToString
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub
#End Region

End Class
