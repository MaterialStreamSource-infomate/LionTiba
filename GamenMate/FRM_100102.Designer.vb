<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_100102
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
        Me.SuspendLayout()
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.Color.DarkGray
        Me.cmdOK.Font = New System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmdOK.ForeColor = System.Drawing.Color.Black
        Me.cmdOK.Location = New System.Drawing.Point(192, 112)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(104, 40)
        Me.cmdOK.TabIndex = 14
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = False
        '
        'FRM_100102
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(488, 163)
        Me.Controls.Add(Me.cmdOK)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Name = "FRM_100102"
        Me.Controls.SetChildIndex(Me.cmdOK, 0)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdOK As System.Windows.Forms.Button

End Class
