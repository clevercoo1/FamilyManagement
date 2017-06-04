Imports Npgsql

Public Class Form1
#Region "Test"

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim cn As New NpgsqlConnection
        cn.ConnectionString = "Server=127.0.0.1;Port=5432;Database=shop;Username=postgres;Password=a789889;" +
                              "Persist Security Info=True;CommandTimeout=3000;"
        Try

            cn.Open()
            Dim strSQL As String
            strSQL = "SELECT * FROM shohin where shohin_id = '0001'"
            Dim ds As New DataSet
            Dim da As New NpgsqlDataAdapter(strSQL, cn)

            da.Fill(ds, "a")
            cn.Dispose()
            TextBox1.Text = ds.Tables("a").Rows(0).ToString
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub


#End Region

End Class
