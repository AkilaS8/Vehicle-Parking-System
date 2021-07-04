Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.IO
Public Class staffdelete
    Dim cnn As New OleDb.OleDbConnection
    Private Sub Staffdelete_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        addcombo()
        clear()
    End Sub
    Private Sub Button2_MouseHover(sender As Object, e As EventArgs) Handles Button2.MouseHover
        Button2.BackColor = Color.FromArgb(135, 10, 228)
        Button2.ForeColor = Color.FromKnownColor(KnownColor.Control)

    End Sub
    Private Sub Button2_MouseLeave(sender As Object, e As EventArgs) Handles Button2.MouseLeave
        Button2.BackColor = Color.FromKnownColor(KnownColor.Control)
        Button2.ForeColor = Color.FromArgb(135, 10, 228)
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint


    End Sub
    Private Sub TextBox10_MouseClick(sender As Object, e As MouseEventArgs) Handles TextBox10.MouseClick
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
        Label21.Text = ""
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

            Label12.Text = dt.Rows(0).Item(0)
            Label15.Text = dt.Rows(0).Item(1)
            Label16.Text = dt.Rows(0).Item(2)
            Label17.Text = dt.Rows(0).Item(3)
            Label18.Text = dt.Rows(0).Item(4)
            Label19.Text = dt.Rows(0).Item(5)
            Label20.Text = dt.Rows(0).Item(6)
            Label13.Text = dt.Rows(0).Item(7)
            Label14.Text = dt.Rows(0).Item(8)
            Label21.Text = dt.Rows(0).Item(9)

        End If
        If Label21.Text = "" Then
            PictureBox1.Image = Nothing
        Else
            PictureBox1.Image = Image.FromFile(Label21.Text)
        End If
    End Sub
    Private Sub clear()
        Label12.Text = ""
        Label15.Text = ""
        Label16.Text = ""
        Label17.Text = ""
        Label18.Text = ""
        Label19.Text = ""
        Label20.Text = ""
        Label13.Text = ""
        Label14.Text = ""
        Label21.Text = ""
        PictureBox1.Image = Nothing
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        clear()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        connection()
        If Not cnn.State = ConnectionState.Open Then
            cnn.Open()
        End If
        'query to add data
        Dim SQLQuery1 = ""
        SQLQuery1 = "DELETE FROM Users WHERE user_id='" & Me.ComboBox1.Text & "'"
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
    End Sub
End Class