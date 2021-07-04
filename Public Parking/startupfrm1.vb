Public Class startupfrm1
    Private Sub Startupfrm1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TransparencyKey = BackColor
        starttimer1.Start()
    End Sub

    Private Sub Starttimer1_Tick(sender As Object, e As EventArgs) Handles starttimer1.Tick
        startprgbar.Value = startprgbar.Value + 5
        If startprgbar.Value = 5 Then
            startlbl2.Text = "Checking files.."
        ElseIf startprgbar.Value = 30 Then
            startlbl2.Text = "Checking Requirements..."
        ElseIf startprgbar.Value = 50 Then
            startlbl2.Text = "Calculating files.."
        ElseIf startprgbar.Value = 55 Then
            startlbl2.Text = "jpeg , png , icon , gif , /0525...."
        ElseIf startprgbar.Value = 65 Then
            startlbl2.Text = "Connecting Database..."
        ElseIf startprgbar.Value = 75 Then
            startlbl2.Text = "..\Debug\Database\Public Parking.mdbs"
        ElseIf startprgbar.Value = 100 Then
            startupfrm2.Show()
            Me.Hide()
            starttimer1.Stop()
        End If
    End Sub
End Class