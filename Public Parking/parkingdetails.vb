Public Class parkingdetails
    Private Sub Parkingdetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Button1_MouseHover(sender As Object, e As EventArgs) Handles Button1.MouseHover
        Button1.BackColor = Color.FromArgb(255, 204, 0)
        Button1.ForeColor = Color.FromKnownColor(KnownColor.Control)

    End Sub
    Private Sub Button2_MouseHover(sender As Object, e As EventArgs) Handles Button2.MouseHover
        Button2.BackColor = Color.FromArgb(255, 204, 0)
        Button2.ForeColor = Color.FromKnownColor(KnownColor.Control)

    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        Button1.BackColor = Color.FromKnownColor(KnownColor.Control)
        Button1.ForeColor = Color.FromArgb(255, 204, 0)
    End Sub
    Private Sub Button2_MouseLeave(sender As Object, e As EventArgs) Handles Button2.MouseLeave
        Button2.BackColor = Color.FromKnownColor(KnownColor.Control)
        Button2.ForeColor = Color.FromArgb(255, 204, 0)
    End Sub
    Private Sub TextBox5_MouseClick(sender As Object, e As MouseEventArgs) Handles TextBox5.MouseClick
        Close()

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        TextBox1.Focus()

    End Sub
End Class