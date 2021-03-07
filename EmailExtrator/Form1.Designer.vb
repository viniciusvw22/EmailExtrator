<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.txtCol = New System.Windows.Forms.TextBox()
        Me.txtExt = New System.Windows.Forms.TextBox()
        Me.btnExt = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtCol
        '
        Me.txtCol.Location = New System.Drawing.Point(12, 12)
        Me.txtCol.Multiline = True
        Me.txtCol.Name = "txtCol"
        Me.txtCol.Size = New System.Drawing.Size(775, 144)
        Me.txtCol.TabIndex = 0
        '
        'txtExt
        '
        Me.txtExt.Location = New System.Drawing.Point(12, 162)
        Me.txtExt.Multiline = True
        Me.txtExt.Name = "txtExt"
        Me.txtExt.Size = New System.Drawing.Size(775, 144)
        Me.txtExt.TabIndex = 1
        '
        'btnExt
        '
        Me.btnExt.Location = New System.Drawing.Point(712, 312)
        Me.btnExt.Name = "btnExt"
        Me.btnExt.Size = New System.Drawing.Size(75, 23)
        Me.btnExt.TabIndex = 2
        Me.btnExt.Text = "Button1"
        Me.btnExt.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 349)
        Me.Controls.Add(Me.btnExt)
        Me.Controls.Add(Me.txtExt)
        Me.Controls.Add(Me.txtCol)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtCol As TextBox
    Friend WithEvents txtExt As TextBox
    Friend WithEvents btnExt As Button
End Class
