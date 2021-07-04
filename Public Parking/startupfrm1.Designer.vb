<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class startupfrm1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(startupfrm1))
        Me.startprgbar = New System.Windows.Forms.ProgressBar()
        Me.startlbl2 = New System.Windows.Forms.Label()
        Me.startlbl1 = New System.Windows.Forms.Label()
        Me.startuppic1 = New System.Windows.Forms.PictureBox()
        Me.starttimer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.startuppic1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'startprgbar
        '
        Me.startprgbar.Location = New System.Drawing.Point(32, 253)
        Me.startprgbar.Name = "startprgbar"
        Me.startprgbar.Size = New System.Drawing.Size(435, 11)
        Me.startprgbar.TabIndex = 7
        '
        'startlbl2
        '
        Me.startlbl2.AutoSize = True
        Me.startlbl2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.startlbl2.Location = New System.Drawing.Point(133, 232)
        Me.startlbl2.Name = "startlbl2"
        Me.startlbl2.Size = New System.Drawing.Size(0, 15)
        Me.startlbl2.TabIndex = 6
        '
        'startlbl1
        '
        Me.startlbl1.AutoSize = True
        Me.startlbl1.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.startlbl1.Location = New System.Drawing.Point(28, 227)
        Me.startlbl1.Name = "startlbl1"
        Me.startlbl1.Size = New System.Drawing.Size(110, 22)
        Me.startlbl1.TabIndex = 5
        Me.startlbl1.Text = "LOADING :"
        '
        'startuppic1
        '
        Me.startuppic1.Image = CType(resources.GetObject("startuppic1.Image"), System.Drawing.Image)
        Me.startuppic1.Location = New System.Drawing.Point(32, 22)
        Me.startuppic1.Name = "startuppic1"
        Me.startuppic1.Size = New System.Drawing.Size(435, 227)
        Me.startuppic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.startuppic1.TabIndex = 4
        Me.startuppic1.TabStop = False
        '
        'starttimer1
        '
        Me.starttimer1.Enabled = True
        Me.starttimer1.Interval = 1000
        '
        'startupfrm1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(504, 305)
        Me.Controls.Add(Me.startprgbar)
        Me.Controls.Add(Me.startlbl2)
        Me.Controls.Add(Me.startlbl1)
        Me.Controls.Add(Me.startuppic1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "startupfrm1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form2"
        CType(Me.startuppic1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents startprgbar As ProgressBar
    Friend WithEvents startlbl2 As Label
    Friend WithEvents startlbl1 As Label
    Friend WithEvents startuppic1 As PictureBox
    Friend WithEvents starttimer1 As Timer
End Class
