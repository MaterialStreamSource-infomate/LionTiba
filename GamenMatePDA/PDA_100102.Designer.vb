<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PDA_100102
    Inherits GamenMatePDA.PDA_100101

    'Form は、コンポーネント一覧に後処理を実行するために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cmdOK = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.cmdOK.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdOK.ForeColor = System.Drawing.Color.White
        Me.cmdOK.Location = New System.Drawing.Point(184, 181)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(104, 40)
        Me.cmdOK.TabIndex = 56
        Me.cmdOK.TabStop = False
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = False
        '
        'PDA_100102
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(468, 233)
        Me.Controls.Add(Me.cmdOK)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Name = "PDA_100102"
        Me.Controls.SetChildIndex(Me.cmdOK, 0)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdOK As System.Windows.Forms.Button

End Class
