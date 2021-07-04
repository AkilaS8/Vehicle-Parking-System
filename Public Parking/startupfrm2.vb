Public Class startupfrm2
    Private Sub Startupfrm2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        Me.TransparencyKey = BackColor
        Me.Label1.Hide()
        Me.Label2.Hide()
        Me.Label3.Hide()
        Me.Label4.Hide()
        Me.ProgressBar2.Hide()
        Me.ProgressBar3.Hide()
        Me.ProgressBar4.Hide()
        Me.ProgressBar5.Hide()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Value = ProgressBar1.Value + 25
        If ProgressBar1.Value = 100 Then
            ProgressBar2.Show()
            Timer1.Stop()
            Timer2.Start()
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        ProgressBar2.Value = ProgressBar2.Value + 25
        If ProgressBar2.Value = 100 Then
            ProgressBar3.Show()
            Timer2.Stop()
            Timer3.Start()
        End If
    End Sub
    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        ProgressBar4.Value = ProgressBar4.Value + 25
        If ProgressBar4.Value = 100 Then
            Timer4.Stop()
            Timer5.Start()
        End If
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        ProgressBar3.Value = ProgressBar3.Value + 25
        If ProgressBar3.Value = 100 Then
            ProgressBar4.Show()
            Timer3.Stop()
            Timer4.Start()
        End If
    End Sub

    Private Sub Timer5_Tick(sender As Object, e As EventArgs) Handles Timer5.Tick
        ProgressBar5.Value = ProgressBar5.Value + 10
        If ProgressBar5.Value = 40 Then
            Me.BackColor = Color.RoyalBlue
        ElseIf ProgressBar5.Value = 60 Then
            Label4.Show()
        ElseIf ProgressBar5.Value = 70 Then
            Label1.Show()
        ElseIf ProgressBar5.Value = 80 Then
            Label2.Show()
        ElseIf ProgressBar5.Value = 90 Then
            Label3.Show()
        ElseIf ProgressBar5.Value = 100 Then
            Timer5.Stop()
            Me.Hide()
            loginfrmback.Show()
            login.Show()

        End If
    End Sub
End Class