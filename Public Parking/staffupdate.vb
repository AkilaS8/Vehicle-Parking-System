Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.IO
Public Class staffupdate
    Dim cnn As New OleDb.OleDbConnection
    Private Sub Staffupdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        addcombo()
        clear()
        addcombo2()

    End Sub
    Private Sub Button1_MouseHover(sender As Object, e As EventArgs) Handles Button1.MouseHover
        Button1.BackColor = Color.FromArgb(135, 10, 228)
        Button1.ForeColor = Color.FromKnownColor(KnownColor.Control)

    End Sub
    Private Sub Button2_MouseHover(sender As Object, e As EventArgs) Handles Button2.MouseHover
        Button2.BackColor = Color.FromArgb(135, 10, 228)
        Button2.ForeColor = Color.FromKnownColor(KnownColor.Control)

    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        Button1.BackColor = Color.FromKnownColor(KnownColor.Control)
        Button1.ForeColor = Color.FromArgb(135, 10, 228)
    End Sub
    Private Sub Button2_MouseLeave(sender As Object, e As EventArgs) Handles Button2.MouseLeave
        Button2.BackColor = Color.FromKnownColor(KnownColor.Control)
        Button2.ForeColor = Color.FromArgb(135, 10, 228)
    End Sub
    Private Sub TextBox10_MouseClick(sender As Object, e As MouseEventArgs) Handles TextBox10.MouseClick
        Close()

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

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
        SQLQuery = "SELECT user_id FROM Users"
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
            sqlr = "SELECT * FROM Users WHERE user_id='" & Me.ComboBox1.Text & "'"

            da = New OleDbDataAdapter(sqlr, cnn)
            da.Fill(dt)

            TextBox9.Text = dt.Rows(0).Item(0)
            TextBox1.Text = dt.Rows(0).Item(1)
            TextBox2.Text = dt.Rows(0).Item(2)
            TextBox3.Text = dt.Rows(0).Item(3)
            TextBox6.Text = dt.Rows(0).Item(4)
            TextBox5.Text = dt.Rows(0).Item(5)
            TextBox4.Text = dt.Rows(0).Item(6)
            ComboBox2.Text = dt.Rows(0).Item(7)
            TextBox7.Text = dt.Rows(0).Item(8)
            Label12.Text = dt.Rows(0).Item(9)

        End If
        If Label12.Text = "" Then
            PictureBox1.Image = Nothing
        Else
            PictureBox1.Image = Image.FromFile(Label12.Text)
        End If

    End Sub

    Private Sub clear()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        ComboBox2.Text = "Select"
        TextBox9.Text = ""
        PictureBox1.Image = Nothing
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        clear()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        BrowseImage()

    End Sub
    Public Sub BrowseImage()

        Dim fd As OpenFileDialog = New OpenFileDialog()

        fd.Title = "Select Picture...."
        fd.InitialDirectory = "C:\"
        fd.Filter = "JPG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|BMP(*.bmp)|*.bmp|PNG(*.png)|*.png|All Files(*.*)|*.*"
        fd.FilterIndex = 1
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            Label12.Text = ""
            Label12.Text = fd.FileName
        End If

        If Label12.Text = "" Then
            PictureBox1.Image = Nothing
        Else
            PictureBox1.Image = Image.FromFile(Label12.Text)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Or ComboBox2.Text = "Select" Or TextBox9.Text = "" Then
            MessageBox.Show("Please complete the required fields.", "Authentication Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Else

            connection()
            If Not cnn.State = ConnectionState.Open Then
                cnn.Open()
            End If
            'query to add data
            Dim SQLQuery1 = ""
            SQLQuery1 = "UPDATE Users SET user_id ='" & Me.TextBox9.Text & "' , firstname ='" & Me.TextBox1.Text & "' , lastname ='" & Me.TextBox2.Text & "' , nic ='" & Me.TextBox3.Text & "' , address ='" & Me.TextBox6.Text & "' , telephone ='" & Me.TextBox5.Text & "' , email ='" & Me.TextBox4.Text & "' , employee_category ='" & Me.ComboBox2.Text & "' , system_password ='" & Me.TextBox7.Text & "' , picture ='" & Me.Label12.Text & "' WHERE user_id ='" & Me.ComboBox1.Text & "'"
            Dim cmd1 As New OleDb.OleDbCommand(SQLQuery1, cnn)

            Try
                cmd1.ExecuteNonQuery()
                MessageBox.Show("Successfully Added", "Successfully Operation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                clear()
                addcombo()
                cnn.Close()

            Catch ex As Exception
                MessageBox.Show("Error Database Connection", "Authentication Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                clear()
            End Try

        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Label12.Text = ""
    End Sub
    Private Sub addcombo2()

        'connect database
        connection()
        cnn.Open()

        Dim SQLQuery = ""
        SQLQuery = "SELECT * FROM emcategory"
        Dim cm As New OleDbCommand(SQLQuery, cnn)
        Dim dr As OleDbDataReader = cm.ExecuteReader

        'add items to combo box
        While dr.Read
            ComboBox2.Items.Add(dr(1).ToString)
        End While

        cnn.Close()
        'add default as first row in database
        Me.ComboBox2.Text = Me.ComboBox2.Items(0).ToString

    End Sub
End Class