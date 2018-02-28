<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_100103
    Inherits GamenMate.FRM_100101

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cmdOK = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.Color.DarkGray
        Me.cmdOK.Font = New System.Drawing.Font("‚l‚r ƒSƒVƒbƒN", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmdOK.ForeColor = System.Drawing.Color.Black
        Me.cmdOK.Location = New System.Drawing.Point(112, 112)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(104, 40)
        Me.cmdOK.TabIndex = 13
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCancel.Font = New System.Drawing.Font("‚l‚r ƒSƒVƒbƒN", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmdCancel.ForeColor = System.Drawing.Color.Black
        Me.cmdCancel.Location = New System.Drawing.Point(272, 112)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(104, 40)
        Me.cmdCancel.TabIndex = 16
        Me.cmdCancel.Text = "ƒLƒƒƒ“ƒZƒ‹"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'FRM_100103
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(488, 163)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Name = "FRM_100103"
        Me.Controls.SetChildIndex(Me.cmdOK, 0)
        Me.Controls.SetChildIndex(Me.cmdCancel, 0)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button

End Class
