Imports Npgsql

Public Class Form1
#Region "Test"
    Dim WithEvents MyHook As New SystemHook()

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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim A As Char = "hello"
        MsgBox(A)

    End Sub

    Private Sub hwnd_MouseHover(sender As Object, e As EventArgs) Handles hwnd.MouseHover
        Try
            MyHook.StartHook(True, True)
            If MyHook.MouseHookEnabled Then
                Panel1.Visible = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MyHook_MouseActivity(sender As Object, e As MouseEventArgs) Handles MyHook.MouseActivity
        Try
            If e.Button = MouseButtons.Left Or e.Button = MouseButtons.Right Then



                If PointToClient(MousePosition).X < PointToClient(Panel1.Location).X Or PointToClient(MousePosition).Y < PointToClient(Panel1.Location).Y Then

                    Panel1.Visible = False

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, Me.Text)
        Finally
            MyHook.UnHook()
        End Try
    End Sub
#End Region

End Class
