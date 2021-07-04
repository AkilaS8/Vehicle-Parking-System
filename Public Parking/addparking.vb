Public Class addparking

    Private Sub Button1_MouseHover(sender As Object, e As EventArgs) Handles Button1.MouseHover
        Button1.BackColor = Color.FromArgb(34, 36, 49)
        Button1.ForeColor = Color.FromArgb(255, 102, 0)
    End Sub

    Private Sub Button2_MouseHover(sender As Object, e As EventArgs) Handles Button2.MouseHover
        Button2.BackColor = Color.FromArgb(34, 36, 49)
        Button2.ForeColor = Color.FromArgb(255, 102, 0)
    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        Button1.BackColor = Color.FromArgb(255, 102, 0)
        Button1.ForeColor = Color.FromArgb(34, 36, 49)
    End Sub

    Private Sub Button2_MouseLeave(sender As Object, e As EventArgs) Handles Button2.MouseLeave
        Button2.BackColor = Color.FromArgb(255, 102, 0)
        Button2.ForeColor = Color.FromArgb(34, 36, 49)
    End Sub

    Private Sub TextBox3_MouseClick(sender As Object, e As MouseEventArgs) Handles TextBox3.MouseClick
        Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        addnewparking.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        bookedparking.Show()

    End Sub

    Private Sub Addparking_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class