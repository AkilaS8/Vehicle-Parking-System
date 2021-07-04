Imports System.Data.OleDb
Public Class exsitparking
    Dim cnn As New OleDb.OleDbConnection
    Dim different = ""
    Dim diff As Double
    Private Sub Exsitparking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        addcombo()
    End Sub

    Private Sub Button3_MouseHover(sender As Object, e As EventArgs) Handles Button3.MouseHover
        Button3.BackColor = Color.FromArgb(0, 176, 240)
        Button3.ForeColor = Color.FromKnownColor(KnownColor.Control)

    End Sub

    Private Sub Button3_MouseLeave(sender As Object, e As EventArgs) Handles Button3.MouseLeave
        Button3.BackColor = Color.FromKnownColor(KnownColor.Control)
        Button3.ForeColor = Color.FromArgb(0, 176, 240)
    End Sub


    Private Sub TextBox5_MouseClick(sender As Object, e As MouseEventArgs) Handles TextBox5.MouseClick
        Close()
    End Sub

    Public Sub connection()
        cnn = New OleDb.OleDbConnection
        cnn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Local Disk D\Degree\Project\Project\Database\Public Parking.accdb"

    End Sub
    Private Sub addcombo()
        ComboBox1.Items.Clear()
        'connect database
        connection()
        cnn.Open()

        Dim SQLQuery = ""
        SQLQuery = "SELECT parkingid FROM parking WHERE booking='NO' AND exsit='NO'"
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
    Private Sub ComboBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox1.KeyPress
        'here now can not type
        e.Handled = True

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If ComboBox1.Text = "" Then
            MessageBox.Show("Please complete the required fields.", "Authentication Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            connection()
            If Not cnn.State = ConnectionState.Open Then
                cnn.Open()
            End If

            Dim ds As New DataSet
            Dim dt As New DataTable
            ds.Tables.Add(dt)
            Dim da As New OleDbDataAdapter
            Dim sqlr = ""
            sqlr = "SELECT * FROM parking WHERE parkingid='" & Me.ComboBox1.Text & "'"

            da = New OleDbDataAdapter(sqlr, cnn)
            da.Fill(dt)

            TextBox1.Text = dt.Rows(0).Item(3)
            TextBox2.Text = dt.Rows(0).Item(4)
            TextBox3.Text = dt.Rows(0).Item(5)
            TextBox4.Text = dt.Rows(0).Item(6)
            TextBox6.Text = dt.Rows(0).Item(7)
            cnn.Close()

            End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim elapsedTime As TimeSpan = DateTime.Parse(TextBox7.Text).Subtract(DateTime.Parse(TextBox6.Text))


        different = elapsedTime.TotalMinutes()

        diff = CDbl(different)

        If TextBox1.Text = "Motor Bick" Then
            TextBox8.Text = Convert.ToDouble(Math.Round(diff * 0.5))
        ElseIf TextBox1.Text = "Three Weel" Then
            TextBox8.Text = Convert.ToDouble(Math.Round(diff * 0.83))
        ElseIf TextBox1.Text = "Moto Car" Then
            TextBox8.Text = Convert.ToDouble(Math.Round(diff * 1.33))
        ElseIf TextBox1.Text = "Bus/Long Vehicle" Then
            TextBox8.Text = Convert.ToDouble(Math.Round(diff * 1.67))
        ElseIf TextBox1.Text = "VIP Vehicle" Then
            TextBox8.Text = Convert.ToDouble(Math.Round(diff * 2))
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        connection()
        If Not cnn.State = ConnectionState.Open Then
            cnn.Open()
        End If
        'query to add data
        Dim SQLQuery1 = ""
        SQLQuery1 = "UPDATE parking SET [endtime]='" & Me.TextBox7.Text & "',[nofees]='" & Me.TextBox8.Text & "' WHERE parkingid='" & Me.ComboBox1.Text & "'"
        Dim cmd1 As New OleDb.OleDbCommand(SQLQuery1, cnn)

        Try

            cmd1.ExecuteNonQuery()
            MessageBox.Show("Successfully Exsit", "Successfully Operation", MessageBoxButtons.OK, MessageBoxIcon.Information)

            cnn.Close()
            connection()
            If Not cnn.State = ConnectionState.Open Then
                cnn.Open()
            End If
            'query to add data
            Dim SQLQuery2 = ""
            SQLQuery2 = "UPDATE parking SET [exsit]='YES' WHERE parkingid='" & ComboBox1.Text & "'"
            Dim cmd2 As New OleDb.OleDbCommand(SQLQuery2, cnn)

            Try
                cmd2.ExecuteNonQuery()
                MessageBox.Show("Successfully Exsit", "Successfully Operation", MessageBoxButtons.OK, MessageBoxIcon.Information)

                clear()
                addcombo()
                cnn.Close()

            Catch ex As Exception
                MessageBox.Show("Error Database Connection", "Authentication Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                clear()

            End Try
        Catch ex As Exception
            MessageBox.Show("Error Database Connection", "Authentication Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            clear()

        End Try


        '
        '
        '


    End Sub
    Private Sub clear()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox8.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        TextBox7.Text = Now.ToLongTimeString()

    End Sub
End Class