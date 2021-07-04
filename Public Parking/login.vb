Imports System.Data.OleDb

Public Class login

    Dim cnn As New OleDb.OleDbConnection

    Private Sub ComboBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles ComboBox1.MouseClick
        ComboBox1.ForeColor = Color.FromArgb(78, 184, 206)

        Panel1.BackColor = Color.FromArgb(78, 184, 206)
        Panel2.BackColor = Color.White
        Panel3.BackColor = Color.White

        PictureBox2.BackColor = Color.FromArgb(78, 184, 206)
        PictureBox3.BackColor = Color.FromArgb(34, 36, 49)
        PictureBox4.BackColor = Color.FromArgb(34, 36, 49)



    End Sub
    Private Sub TextBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles TextBox1.MouseClick
        TextBox1.Text = ""
        TextBox1.ForeColor = Color.FromArgb(78, 184, 206)

        Panel1.BackColor = Color.White
        Panel2.BackColor = Color.FromArgb(78, 184, 206)
        Panel3.BackColor = Color.White

        PictureBox2.BackColor = Color.FromArgb(34, 36, 49)
        PictureBox3.BackColor = Color.FromArgb(78, 184, 206)
        PictureBox4.BackColor = Color.FromArgb(34, 36, 49)

    End Sub

    Private Sub TextBox2_MouseClick(sender As Object, e As MouseEventArgs) Handles TextBox2.MouseClick
        TextBox2.Text = ""
        TextBox2.ForeColor = Color.FromArgb(78, 184, 206)

        Panel1.BackColor = Color.White
        Panel2.BackColor = Color.White
        Panel3.BackColor = Color.FromArgb(78, 184, 206)

        PictureBox2.BackColor = Color.FromArgb(34, 36, 49)
        PictureBox3.BackColor = Color.FromArgb(34, 36, 49)
        PictureBox4.BackColor = Color.FromArgb(78, 184, 206)
    End Sub
    Private Sub TextBox3_MouseClick(sender As Object, e As MouseEventArgs) Handles TextBox3.MouseClick
        Close()
        startupfrm1.Close()
        startupfrm2.Close()
        loginfrmback.Close()
    End Sub
    Private Sub Button1_MouseHover(sender As Object, e As EventArgs) Handles Button1.MouseHover
        Button1.BackColor = Color.FromArgb(34, 36, 49)
        Button1.ForeColor = Color.FromArgb(78, 184, 206)
    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        Button1.BackColor = Color.FromArgb(78, 184, 206)
        Button1.ForeColor = Color.FromArgb(34, 36, 49)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click



        'required all fields are fill
        If TextBox1.Text = "" Or TextBox2.Text = "" Or ComboBox1.Text = "select" Then
            MessageBox.Show("Please complete the required fields.", "Authentication Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Else
            'database connection
            connection()

            Try
                'SQL quary
                Dim sql1 As String = "SELECT * FROM Users WHERE user_id = '" & TextBox1.Text & "' AND system_password = '" & TextBox2.Text & "' AND employee_category = '" & ComboBox1.Text & "'"
                Dim sqllog As New System.Data.OleDb.OleDbCommand(sql1)

                sqllog.Connection = cnn
                cnn.Open()

                Dim sqlReadlog As System.Data.OleDb.OleDbDataReader = sqllog.ExecuteReader()

                If sqlReadlog.Read() Then
                    Homescreen.Show()
                    Me.Hide()
                    loginfrmback.Close()

                Else
                    MessageBox.Show("Userid or Password or your state do not match.", "Authentication Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                End If

            Catch ex As Exception
                MessageBox.Show("Failed to connect to Database.", "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If



    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        addcombo()

    End Sub
    Private Sub addcombo()

        'connect database
        connection()
        cnn.Open()

        Dim SQLQuery = ""
        SQLQuery = "SELECT * FROM emcategory"
        Dim cm As New OleDbCommand(SQLQuery, cnn)
        Dim dr As OleDbDataReader = cm.ExecuteReader

        'add items to combo box
        While dr.Read
            ComboBox1.Items.Add(dr(1).ToString)
        End While

        cnn.Close()
        'add default as first row in database
        Me.ComboBox1.Text = Me.ComboBox1.Items(0).ToString

    End Sub

    Private Sub ComboBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox1.KeyPress
        'here now can not type
        e.Handled = True

    End Sub
    Public Sub connection()
        cnn = New OleDb.OleDbConnection
        cnn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Local Disk D\Degree\Year 1\Vehical Parking System Project\Project\Database\Public Parking.accdb"

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub


End Class