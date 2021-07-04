Public Class addbokking
    Dim cnn As New OleDb.OleDbConnection
    Dim diffrent As Integer
    Dim different1 As Integer
    Private Sub Addbokking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connection()
        parkingid()
        addcombo()
        clear()
    End Sub
    Private Sub TextBox6_MouseClick(sender As Object, e As MouseEventArgs) Handles TextBox6.MouseClick
        Close()
    End Sub
    Private Sub Button1_MouseHover(sender As Object, e As EventArgs) Handles Button1.MouseHover
        Button1.BackColor = Color.FromArgb(0, 153, 153)
        Button1.ForeColor = Color.FromKnownColor(KnownColor.Control)

    End Sub
    Private Sub Button2_MouseHover(sender As Object, e As EventArgs) Handles Button2.MouseHover
        Button2.BackColor = Color.FromArgb(0, 153, 153)
        Button2.ForeColor = Color.FromKnownColor(KnownColor.Control)

    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        Button1.BackColor = Color.FromKnownColor(KnownColor.Control)
        Button1.ForeColor = Color.FromArgb(0, 153, 153)
    End Sub
    Private Sub Button2_MouseLeave(sender As Object, e As EventArgs) Handles Button2.MouseLeave
        Button2.BackColor = Color.FromKnownColor(KnownColor.Control)
        Button2.ForeColor = Color.FromArgb(0, 153, 153)
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        TextBox1.Focus()

    End Sub
    Private Sub addcombo()

        'connect database
        connection()
        cnn.Open()

        Dim SQLQuery = ""
        SQLQuery = "SELECT category FROM vehicle"
        Dim cm As New OleDb.OleDbCommand(SQLQuery, cnn)
        Dim dr As OleDb.OleDbDataReader = cm.ExecuteReader


        'add items to combo box
        While dr.Read
            ComboBox1.Items.Add(dr(0).ToString)
        End While

        cnn.Close()
        'add default as first row in database
        Me.ComboBox1.Text = Me.ComboBox1.Items(0).ToString

    End Sub
    Public Sub connection()
        cnn = New OleDb.OleDbConnection
        cnn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Local Disk D\Degree\Project\Project\Database\Public Parking.accdb"

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        prislist2.Show()

    End Sub
    Private Sub parkingid()

        connection()
        cnn.Open()

        Dim dapid As New OleDb.OleDbDataAdapter("SELECT * from booking ORDER BY bookingid", cnn)
        Dim dtpid As New DataTable
        dapid.Fill(dtpid)

        Dim dap1 As New OleDb.OleDbDataAdapter("SELECT count(bookingid) from booking", cnn)
        Dim dtp1 As New DataTable
        dap1.Fill(dtp1)

        Label9.Text = "BID0" & dtp1.Rows(0).Item(0) + 1
        cnn.Close()

    End Sub
    Private Sub ComboBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox2.KeyPress
        'here now can not type
        e.Handled = True

    End Sub
    Private Sub ComboBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox1.KeyPress
        'here now can not type
        e.Handled = True

    End Sub
    Private Sub ComboBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox3.KeyPress
        'here now can not type
        e.Handled = True

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        different1 = DateDiff(DateInterval.Day, DateTimePicker2.Value, DateTimePicker1.Value)
        diffrent = DateDiff(DateInterval.Hour, ComboBox2.SelectedItem, ComboBox3.SelectedItem)

        'check if all fields are completly fill
        If Me.TextBox1.Text = "" Or Me.TextBox2.Text = "" Or Me.ComboBox1.Text = "Select" Or Me.ComboBox1.Text = "Motor Bick" Or Me.ComboBox1.Text = "Three Weel" Or Me.TextBox3.Text = "" Or Me.TextBox4.Text = "" Or Me.TextBox7.Text = "" Or Me.ComboBox2.Text = "" Or Me.ComboBox3.Text = "" Or diffrent <= 0 Or different1 <= 0 Then
            MessageBox.Show("Complete the required fields OR Check time you slected OR Check date you selected", "Authentication Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Else
            connection()
            If Not cnn.State = ConnectionState.Open Then
                cnn.Open()
            End If
            'query to add data
            Dim SQLQuery2 = ""
            SQLQuery2 = "INSERT INTO booking ([bookingid],[name],[telephone],[category],[vehicleno],[slotid],[date],[starttime],[endtime],[fees],[add]) VALUES ('" & Me.Label9.Text & "','" & Me.TextBox1.Text & "','" & Me.TextBox2.Text & "','" & Me.ComboBox1.Text & "','" & Me.TextBox3.Text & "','" & Me.TextBox7.Text & "','" & Me.Label12.Text & "','" & Me.ComboBox2.Text & "','" & Me.ComboBox3.Text & "','" & Me.TextBox4.Text & "','NO')"

            Dim cmd As New OleDb.OleDbCommand(SQLQuery2, cnn)

            Try
                cmd.ExecuteNonQuery()
                MessageBox.Show("Successfully Added", "Successfully Operation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                parkingid()
                clear()
                cnn.Close()

            Catch ex As Exception
                MessageBox.Show("Error Database Connection", "Authentication Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                clear()
            End Try
        End If
    End Sub
    Private Sub clear()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox7.Text = ""
        ComboBox1.Text = "Select"
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        DateTimePicker1.Value = Now()
        Label12.Text = DateTimePicker1.Value.ToShortDateString
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        clear()

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        Label12.Text = DateTimePicker1.Value.ToShortDateString

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        diffrent = DateDiff(DateInterval.Hour, ComboBox2.SelectedItem, ComboBox3.SelectedItem)
        If ComboBox1.Text = "Moto Car" Then
            TextBox4.Text = Convert.ToDouble(diffrent * 100)
        ElseIf ComboBox1.Text = "Bus/Long Vehicle" Then
            TextBox4.Text = Convert.ToDouble(diffrent * 120)
        ElseIf ComboBox1.Text = "VIP Vehicle" Then
            TextBox4.Text = Convert.ToDouble(diffrent * 150)
        End If
    End Sub
End Class