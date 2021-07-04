Imports System.Data.OleDb
Public Class bookedparking
    Dim cnn As New OleDb.OleDbConnection
    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        Button1.BackColor = Color.FromKnownColor(KnownColor.Control)
        Button1.ForeColor = Color.FromArgb(255, 102, 0)
    End Sub
    Private Sub Button1_MouseHover(sender As Object, e As EventArgs) Handles Button1.MouseHover
        Button1.BackColor = Color.FromArgb(255, 102, 0)
        Button1.ForeColor = Color.FromKnownColor(KnownColor.Control)

    End Sub
    Private Sub TextBox5_MouseClick(sender As Object, e As MouseEventArgs) Handles TextBox5.MouseClick
        Close()
        addparking.Close()

    End Sub

    Private Sub Bookedparking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        parkingid()
        addcombo()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
    Public Sub connection()
        cnn = New OleDb.OleDbConnection
        cnn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Local Disk D\Degree\Project\Project\Database\Public Parking.accdb"

    End Sub
    Private Sub addcombo()

        ComboBox2.Items.Clear()
        'connect database
        connection()
        cnn.Open()

        Dim SQLQuery = ""
        SQLQuery = "SELECT bookingid FROM booking WHERE add='NO'"
        Dim cm As New OleDb.OleDbCommand(SQLQuery, cnn)
        Dim dr As OleDb.OleDbDataReader = cm.ExecuteReader


        'add items to combo box
        While dr.Read
            ComboBox2.Items.Add(dr(0).ToString)
        End While

        cnn.Close()
        'add default as first row in database
        Me.ComboBox2.Text = Me.ComboBox2.Items(0).ToString

    End Sub
    Private Sub ComboBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox2.KeyPress
        'here now can not type
        e.Handled = True

    End Sub
    Private Sub parkingid()

        connection()
        cnn.Open()

        Dim dapid As New OleDb.OleDbDataAdapter("SELECT * from parking ORDER BY parkingid", cnn)
        Dim dtpid As New DataTable
        dapid.Fill(dtpid)

        Dim dap1 As New OleDb.OleDbDataAdapter("SELECT count(parkingid) from parking", cnn)
        Dim dtp1 As New DataTable
        dap1.Fill(dtp1)

        Label12.Text = "PID0" & dtp1.Rows(0).Item(0) + 1
        cnn.Close()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        If ComboBox2.Text = "" Then
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
            sqlr = "SELECT * FROM booking WHERE bookingid='" & Me.ComboBox2.Text & "'"

            da = New OleDbDataAdapter(sqlr, cnn)
            da.Fill(dt)

            TextBox1.Text = dt.Rows(0).Item(1)
            TextBox2.Text = dt.Rows(0).Item(2)
            TextBox3.Text = dt.Rows(0).Item(3)
            TextBox4.Text = dt.Rows(0).Item(4)
            TextBox6.Text = dt.Rows(0).Item(5)
            TextBox7.Text = dt.Rows(0).Item(6)
            TextBox8.Text = dt.Rows(0).Item(7)
            TextBox9.Text = dt.Rows(0).Item(8)
            TextBox10.Text = dt.Rows(0).Item(9)

            cnn.Close()

        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        connection()
        If Not cnn.State = ConnectionState.Open Then
            cnn.Open()
        End If
        'query to add data
        Dim SQLQuery1 = ""
        SQLQuery1 = "INSERT INTO parking ([parkingid],[name],[telephone],[category],[vehicleno],[slotid],[date],[starttime],[endtime],[bofees],[booking],[exsit]) VALUES ('" & Me.Label12.Text & "','" & Me.TextBox1.Text & "','" & Me.TextBox2.Text & "','" & Me.TextBox3.Text & "','" & Me.TextBox4.Text & "','" & Me.TextBox6.Text & "','" & Me.TextBox7.Text & "','" & Me.TextBox8.Text & "','" & Me.TextBox9.Text & "','" & Me.TextBox10.Text & "','YES','NO')"

        Dim cmd1 As New OleDb.OleDbCommand(SQLQuery1, cnn)

        Try
            cmd1.ExecuteNonQuery()
            MessageBox.Show("Successfully Added", "Successfully Operation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            parkingid()
            clear()
            cnn.Close()

            connection()
            If Not cnn.State = ConnectionState.Open Then
                cnn.Open()
            End If
            'query to add data
            Dim SQLQuery2 = ""
            SQLQuery2 = "UPDATE booking SET [add]='YES' WHERE bookingid='" & ComboBox2.Text & "'"
            Dim cmd2 As New OleDb.OleDbCommand(SQLQuery2, cnn)

            Try
                cmd2.ExecuteNonQuery()
                MessageBox.Show("Successfully Added", "Successfully Operation", MessageBoxButtons.OK, MessageBoxIcon.Information)

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
    End Sub
    Private Sub clear()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
    End Sub
End Class