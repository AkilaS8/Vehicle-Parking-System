Public Class staffmenu
    Private Sub Staffmenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Button1_MouseHover(sender As Object, e As EventArgs) Handles Button1.MouseHover
        Button1.BackColor = Color.FromArgb(34, 36, 49)
        Button1.ForeColor = Color.FromArgb(135, 10, 228)
    End Sub

    Private Sub Button2_MouseHover(sender As Object, e As EventArgs) Handles Button2.MouseHover
        Button2.BackColor = Color.FromArgb(34, 36, 49)
        Button2.ForeColor = Color.FromArgb(135, 10, 228)
    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        Button1.BackColor = Color.FromArgb(135, 10, 228)
        Button1.ForeColor = Color.FromArgb(34, 36, 49)
    End Sub

    Private Sub Button2_MouseLeave(sender As Object, e As EventArgs) Handles Button2.MouseLeave
        Button2.BackColor = Color.FromArgb(135, 10, 228)
        Button2.ForeColor = Color.FromArgb(34, 36, 49)
    End Sub

    Private Sub Button3_MouseHover(sender As Object, e As EventArgs) Handles Button3.MouseHover
        Button3.BackColor = Color.FromArgb(34, 36, 49)
        Button3.ForeColor = Color.FromArgb(135, 10, 228)
    End Sub

    Private Sub Button4_MouseHover(sender As Object, e As EventArgs) Handles Button4.MouseHover
        Button4.BackColor = Color.FromArgb(34, 36, 49)
        Button4.ForeColor = Color.FromArgb(135, 10, 228)
    End Sub

    Private Sub Button3_MouseLeave(sender As Object, e As EventArgs) Handles Button3.MouseLeave
        Button3.BackColor = Color.FromArgb(135, 10, 228)
        Button3.ForeColor = Color.FromArgb(34, 36, 49)
    End Sub

    Private Sub Button4_MouseLeave(sender As Object, e As EventArgs) Handles Button4.MouseLeave
        Button4.BackColor = Color.FromArgb(135, 10, 228)
        Button4.ForeColor = Color.FromArgb(34, 36, 49)
    End Sub
    Private Sub TextBox3_MouseClick(sender As Object, e As MouseEventArgs) Handles TextBox3.MouseClick
        Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Satff.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        staffview.Show()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        staffupdate.Show()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        staffdelete.Show()

    End Sub
End Class