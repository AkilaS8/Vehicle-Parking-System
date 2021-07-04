Imports System.Data.OleDb
Imports System.IO
Public Class Satff
    Dim cnn As New OleDb.OleDbConnection
    Private abyt As Byte()
    Dim constr As String
    Dim fo As New OpenFileDialog
    Dim imgpath As String
    Private Sub Satff_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        addcombo()
        clear()
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
        TextBox1.Focus()
    End Sub
    Public Sub connection()
        cnn = New OleDb.OleDbConnection
        cnn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Local Disk D\Degree\Project\Project\Database\Public Parking.accdb"

    End Sub
    Private Sub addcombo()

        'connect database
        connection()
        cnn.Open()

        Dim SQLQuery = ""
        SQLQuery = "SELECT * FROM emcategory"
        Dim cm As New OleDb.OleDbCommand(SQLQuery, cnn)
        Dim dr As OleDb.OleDbDataReader = cm.ExecuteReader

        'add items to combo box
        While dr.Read
            ComboBox1.Items.Add(dr(1).ToString)
        End While

        cnn.Close()
        'add default as first row in database
        Me.ComboBox1.Text = Me.ComboBox1.Items(0).ToString

    End Sub
    Private Sub clear()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox9.Text = ""
        ComboBox1.Text = "Select"
        Label11.Text = ""
        PictureBox1.Image = Nothing
    End Sub
    Private Sub ComboBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox1.KeyPress
        'here now can not type
        e.Handled = True

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Or TextBox9.Text = "" Or ComboBox1.Text = "Select" Then
            MessageBox.Show("Please complete the required fields.", "Authentication Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Else

            connection()
            If Not cnn.State = ConnectionState.Open Then
                cnn.Open()
            End If
            'query to add data
            Dim SQLQuery1 = ""
            SQLQuery1 = "INSERT INTO Users([User_id],[firstname],[lastname],[nic],[address],[telephone],[email],[employee_category],[system_password],[picture]) VALUES ('" & Me.TextBox9.Text & "','" & Me.TextBox1.Text & "','" & Me.TextBox2.Text & "','" & Me.TextBox3.Text & "','" & Me.TextBox6.Text & "','" & Me.TextBox5.Text & "','" & Me.TextBox4.Text & "','" & Me.ComboBox1.Text & "','" & Me.TextBox7.Text & "','" & Me.Label11.Text & "')"
            Dim cmd1 As New OleDb.OleDbCommand(SQLQuery1, cnn)

            Try
                cmd1.ExecuteNonQuery()
                MessageBox.Show("Successfully Added", "Successfully Operation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                clear()
                cnn.Close()

            Catch ex As Exception
                MessageBox.Show("Error Database Connection", "Authentication Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                clear()
            End Try

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        clear()
    End Sub
    Public Sub BrowseImage()

        Label11.Text = ""

        Dim fd As OpenFileDialog = New OpenFileDialog()

        fd.Title = "Select Picture...."
        fd.InitialDirectory = "C:\"
        fd.Filter = "JPG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|BMP(*.bmp)|*.bmp|PNG(*.png)|*.png|All Files(*.*)|*.*"
        fd.FilterIndex = 1
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            Label11.Text = fd.FileName
        End If

        If Label11.Text = "" Then
            PictureBox1.Image = Nothing
        Else
            PictureBox1.Image = Image.FromFile(Label11.Text)
        End If


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        BrowseImage()
    End Sub
End Class