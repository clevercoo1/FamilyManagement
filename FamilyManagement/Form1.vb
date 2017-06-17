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
        If Label1.Text = "启动" Then
            MyHook.UnHook()
            Label1.Text = "关闭"
            Return
        End If
        MyHook.StartHook(True, True)
        If MyHook.MouseHookEnabled Then
            Label1.Text = "启动"
        End If
    End Sub

    Private Sub Form1_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        If Panel1.Visible = True Then
            If e.Button = MouseButtons.Left Or e.Button = MouseButtons.Right Then
                If Math.Abs(PointToClient(MousePosition).Y) < Panel1.Top Or Math.Abs(PointToClient(MousePosition).X) < Panel1.Left Then
                    Panel1.Visible = False
                End If
                If Math.Abs(PointToClient(MousePosition).Y) > Panel1.Top + Panel1.Size.Height Or Math.Abs(PointToClient(MousePosition).X) > Panel1.Left + +Panel1.Size.Width Then
                    Panel1.Visible = False
                End If
            End If
        End If
    End Sub

    Private Sub hwnd_MouseHover(sender As Object, e As EventArgs) Handles hwnd.MouseHover
        Try


            Panel1.Visible = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, Me.Text)
        End Try
    End Sub

    Private Sub MyHook_MouseActivity(sender As Object, e As MouseEventArgs) Handles MyHook.MouseActivity
        Try
            If Panel1.Visible = True Then
                If e.Button = MouseButtons.Left Or e.Button = MouseButtons.Right Then
                    If Math.Abs(PointToClient(MousePosition).Y) < Panel1.Top Or Math.Abs(PointToClient(MousePosition).X) < Panel1.Left Then
                        Panel1.Visible = False
                    End If
                    If Math.Abs(PointToClient(MousePosition).Y) > Panel1.Top + Panel1.Size.Height Or Math.Abs(PointToClient(MousePosition).X) > Panel1.Left + +Panel1.Size.Width Then
                        Panel1.Visible = False
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, Me.Text)
        End Try
    End Sub
#End Region

End Class
